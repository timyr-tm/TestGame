using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TestGame.Api.Registry;

public partial class RegistryPath:
    IEquatable<RegistryPath>,
    IParsable<RegistryPath>,
    IEqualityOperators<RegistryPath, RegistryPath, bool>,
    IDivisionOperators<RegistryPath, string, RegistryPath>,
    IDivisionOperators<RegistryPath, IEnumerable<string>, RegistryPath>
{
    [GeneratedRegex(@"^[\S-[:/]]+$", RegexOptions.Singleline | RegexOptions.Compiled)]
    private static partial Regex PathItemMatch { get; }
    
    [GeneratedRegex(@"^(?'Namespace'[\S-[:/]]+):(?:(?'Item'[\S-[:/]]+)/?)+$", RegexOptions.Singleline | RegexOptions.Compiled)]
    private static partial Regex FullPathMatch { get; }

    public string Namespace { get; }
    public IImmutableList<string> Items { get; }

    private RegistryPath(string @namespace, IImmutableList<string> items, bool @checked) {
        if (@checked && !PathItemMatch.IsMatch(@namespace))
            throw new ArgumentException("", nameof(@namespace));
        if (@checked && items.Count >= 1 && items.Any(item => !PathItemMatch.IsMatch(item)))
            throw new ArgumentException("", nameof(@namespace));
        Namespace = @namespace;
        Items = items;
    }

    public RegistryPath(string @namespace, params IEnumerable<string> items):
        this(@namespace, items.ToImmutableList(), true) { }

    private static RegistryPath? TryParse(string? str) {
        if (string.IsNullOrWhiteSpace(str))
            return null;
        Match match = FullPathMatch.Match(str);
        if (!match.Success)
            return null;
        return new RegistryPath(
            match.Groups["Namespace"].Value,
            match.Groups["Item"].Captures
                .Select(capture => capture.Value)
                .ToImmutableList(),
            false
        );
    }

    public static RegistryPath Parse(string str, IFormatProvider? provider)
        => TryParse(str) ?? throw new FormatException();

    public static bool TryParse([NotNullWhen(true)] string? str, IFormatProvider? provider, [MaybeNullWhen(false)] out RegistryPath result) {
        result = TryParse(str);
        return result is not null;
    }

    public override string ToString()
        => string.Concat(Namespace, ':', string.Join('/', Items));

    public bool Equals(RegistryPath? other)
        => other is not null
            && StringComparer.Ordinal.Equals(Namespace, other.Namespace)
            && Items.SequenceEqual(other.Items, StringComparer.Ordinal);

    public override bool Equals(object? obj)
        =>obj is RegistryPath other && Equals(other);

    public override int GetHashCode() {
        HashCode hashCode = new();
        hashCode.Add(Namespace, StringComparer.Ordinal);
        foreach (string item in Items)
            hashCode.Add(item, StringComparer.Ordinal);
        return hashCode.ToHashCode();
    }

    public static bool operator ==(RegistryPath? self, RegistryPath? other)
        => self is not null && self.Equals(other);

    public static bool operator !=(RegistryPath? self, RegistryPath? other)
        => self is null || !self.Equals(other);

    public static RegistryPath operator /(RegistryPath self, string item)
        => new(self.Namespace, self.Items.Add(item));

    public static RegistryPath operator /(RegistryPath self, IEnumerable<string> items)
        => new(self.Namespace, self.Items.AddRange(items));
}
