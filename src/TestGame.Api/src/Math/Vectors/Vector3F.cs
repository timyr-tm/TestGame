using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public readonly record struct Vector3F(float X, float Y, float Z):
	IFloatingVector<Vector3F, float>,
	IAdditionOperators<Vector3F, float, Vector3F>,
	ISubtractionOperators<Vector3F, float, Vector3F>,
	IMultiplyOperators<Vector3F, float, Vector3F>,
	IDivisionOperators<Vector3F, float, Vector3F>
{
	public static Vector3F MaxValue => new(float.MaxValue, float.MaxValue, float.MaxValue);
	public static Vector3F MinValue => new(float.MinValue, float.MinValue, float.MinValue);

    public float LengthSquared
        => X * X + Y * Y + Z * Z;

    public float Length => float.Sqrt(LengthSquared);

	public float this[int index] => index switch {
		0 => X,
		1 => Y,
		2 => Z,
        var _ => throw new ArgumentOutOfRangeException(
            nameof(index), index,
            $"Invalid vector component index. Expected range: [0, 2], but got {index}."
        )
	};

	public float this[char name] => name switch {
		'x' => X,
		'y' => Y,
		'z' => Z,
        var _ => throw new ArgumentException(
            $"Invalid vector component name. Expected 'x', 'y' or 'z', but got '{name}'.",
            nameof(name)
        )
	};

	public int CompareTo(Vector3F other) {
		if (this < other)
			return -1;
		return this > other ? 1 : 0;
	}

	public static Vector3F Round(Vector3F vector, int digits = 0, MidpointRounding mode = MidpointRounding.ToEven) => new(
		float.Round(vector.X, digits, mode),
		float.Round(vector.Y, digits, mode),
		float.Round(vector.Z, digits, mode)
	);

	public static Vector3F Abs(Vector3F value) => new(
		float.Abs(value.X),
		float.Abs(value.Y),
		float.Abs(value.Z)
	);

	public static Vector3F Min(Vector3F first, Vector3F second) => new(
        float.Min(first.X, second.X),
        float.Min(first.Y, second.Y),
        float.Min(first.Z, second.Z)
    );

	public static Vector3F Max(Vector3F first, Vector3F second)  => new(
        float.Max(first.X, second.X),
        float.Max(first.Y, second.Y),
        float.Max(first.Z, second.Z)
    );

	public static Vector3F Clamp(Vector3F value, Vector3F min, Vector3F max) => new(
		float.Clamp(value.X, min.X, max.X),
		float.Clamp(value.Y, min.Y, max.Y),
		float.Clamp(value.Z, min.Z, max.Z)
	);

	public static Vector3F Clamp(Vector3F value, float min, float max) => new(
		float.Clamp(value.X, min, max),
		float.Clamp(value.Y, min, max),
		float.Clamp(value.Z, min, max)
	);

	public bool Equals(Vector3F other)
		=> X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

	public override int GetHashCode() => HashCode.Combine(X, Y, Z);

	public override string ToString() => $"Vector3F({X}, {Y}, {Z})";
	
	public string ToString(string? format, IFormatProvider? provider)
		=> $"Vector3F({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)})";

	public static Vector3F operator +(Vector3F self) => self;

	public static Vector3F operator -(Vector3F self) => new(
		-self.X, -self.Y, -self.Z
	);

	public static Vector3F operator ++(Vector3F self) => new(
		self.X + 1, self.Y + 1, self.Z + 1
	);

	public static Vector3F operator --(Vector3F self) => new(
		self.X - 1, self.Y - 1, self.Z - 1
	);

	public static Vector3F operator +(Vector3F self, Vector3F other) => new(
		self.X + other.X,
		self.Y + other.Y,
		self.Z + other.Z
	);

	public static Vector3F operator +(Vector3F self, float other) => new(
		self.X + other,
		self.Y + other,
		self.Z + other
	);

	public static Vector3F operator -(Vector3F self, Vector3F other) => new(
		self.X - other.X,
		self.Y - other.Y,
		self.Z - other.Z
	);

	public static Vector3F operator -(Vector3F self, float other) => new(
		self.X - other,
		self.Y - other,
		self.Z - other
	);

	public static Vector3F operator *(Vector3F self, Vector3F other) => new(
		self.X * other.X,
		self.Y * other.Y,
		self.Z * other.Z
	);

	public static Vector3F operator *(Vector3F self, float other) => new(
		self.X * other,
		self.Y * other,
		self.Z * other
	);

	public static Vector3F operator /(Vector3F self, Vector3F other) => new(
		self.X / other.X,
		self.Y / other.Y,
		self.Z / other.Z
	);

	public static Vector3F operator /(Vector3F self, float other) => new(
		self.X / other,
		self.Y / other,
		self.Z / other
	);

	public static Vector3F operator %(Vector3F self, Vector3F other) => new(
		self.X % other.X, self.Y % other.Y, self.Z % other.Z
	);

	public static bool operator >(Vector3F self, Vector3F other)
		=> self.X > other.X && self.Y > other.Y && self.Z > other.Z;

	public static bool operator >=(Vector3F self, Vector3F other)
        => self.X >= other.X && self.Y >= other.Y && self.Z >= other.Z;

	public static bool operator <(Vector3F self, Vector3F other)
        => self.X < other.X && self.Y < other.Y && self.Z < other.Z;

	public static bool operator <=(Vector3F self, Vector3F other)
        => self.X <= other.X && self.Y <= other.Y && self.Z <= other.Z;
	
	public static implicit operator Vector3F((float X, float Y, float Z) other)
		=> new(other.X, other.Y, other.Z);

	public static explicit operator ValueTuple<float, float, float>(Vector3F self)
		=> new(self.X, self.Y, self.Z);
}
