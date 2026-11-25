using TestGame.Api.Registry;

namespace TestGame.Api.Test.Registry;

public class RegistryPathTest {
    public static readonly TheoryData<string> ParseExceptionsData = [
        string.Empty,
        "name space:a/b/c",
        "namespace:a /b/ c"
    ];
    
    [Theory]
    [InlineData("", new string[] {})]
    [InlineData("name space", new[] {"a", "b", "c"})]
    [InlineData("namespace", new[] {"a ", "b", " c"})]
    public void ConstructorExceptionsTest(string @namespace, string[] items) => Assert.Throws<ArgumentException>(
        () => new RegistryPath(@namespace, items)
    );

    [Theory, MemberData(nameof(ParseExceptionsData))]
    public void ParseExceptionsTest(string path) => Assert.Throws<FormatException>(
        () => RegistryPath.Parse(path, null)
    );
    
    [Theory, MemberData(nameof(ParseExceptionsData))]
    public void TryParseExceptionsTest(string path) => Assert.False(
        RegistryPath.TryParse(path, null, out RegistryPath? _)
    );
}
