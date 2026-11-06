using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public readonly record struct Vector2F(float X, float Y):
	IFloatingVector<Vector2F, float>,
	IAdditionOperators<Vector2F, float, Vector2F>,
	ISubtractionOperators<Vector2F, float, Vector2F>,
	IMultiplyOperators<Vector2F, float, Vector2F>,
	IDivisionOperators<Vector2F, float, Vector2F>
{
	public static Vector2F MaxValue => new(float.MaxValue, float.MaxValue);
	public static Vector2F MinValue => new(float.MinValue, float.MinValue);
    
    public float LengthSquared => X * X + Y * Y;
    
    public float Length => float.Sqrt(LengthSquared);

	public float this[int index] => index switch {
		0 => X,
		1 => Y,
		var _ => throw new ArgumentOutOfRangeException(
            nameof(index), index,
            $"Invalid vector component index. Expected range: [0, 1], but got {index}."
        )
	};

	public float this[char name] => name switch {
		'x' => X,
		'y' => Y,
		var _ => throw new ArgumentException(
            $"Invalid vector component name. Expected 'x' or 'y', but got '{name}'.",
            nameof(name)
        )
	};

	public int CompareTo(Vector2F other) {
		if (this < other)
			return -1;
		return this > other ? 1 : 0;
	}

	public static Vector2F Round(Vector2F vector, int digits = 0, MidpointRounding mode = MidpointRounding.ToEven) => new(
		float.Round(vector.X, digits, mode),
		float.Round(vector.Y, digits, mode)
	);

	public static Vector2F Abs(Vector2F value) => new(float.Abs(value.X), float.Abs(value.Y));

	public static Vector2F Min(Vector2F first, Vector2F second)
		=> first < second
			? first
			: second;

	public static Vector2F Max(Vector2F first, Vector2F second)
		=> first > second
			? first
			: second;

	public static Vector2F Clamp(Vector2F value, Vector2F min, Vector2F max) => new(
		float.Clamp(value.X, min.X, max.X),
		float.Clamp(value.Y, min.Y, max.Y)
	);

	public static Vector2F Clamp(Vector2F value, float min, float max) => new(
		float.Clamp(value.X, min, max),
		float.Clamp(value.Y, min, max)
	);
	
	public bool Equals(Vector2F other) => X.Equals(other.X) && Y.Equals(other.Y);

	public override int GetHashCode() => HashCode.Combine(X, Y);

	public override string ToString() => $"Vector2F({X}, {Y})";
	
	public string ToString(string? format, IFormatProvider? provider)
		=> $"Vector2F({X.ToString(format, provider)}, {Y.ToString(format, provider)})";

	public static Vector2F operator + (Vector2F self) => self;

	public static Vector2F operator - (Vector2F self) => new(-self.X, -self.Y);

	public static Vector2F operator ++(Vector2F value) => new(value.X + 1, value.Y + 1);

	public static Vector2F operator --(Vector2F value) => new(value.X - 1, value.Y - 1);

	public static Vector2F operator + (Vector2F self, Vector2F other) => new(
		self.X + other.X,
		self.Y + other.Y
	);

	public static Vector2F operator + (Vector2F self, float other) => new(
		self.X + other,
		self.Y + other
	);

	public static Vector2F operator - (Vector2F self, Vector2F other) => new(
		self.X - other.X,
		self.Y - other.Y
	);

	public static Vector2F operator - (Vector2F self, float other) => new(
		self.X - other,
		self.Y - other
	);

	public static Vector2F operator * (Vector2F self, Vector2F other) => new(
		self.X * other.X,
		self.Y * other.Y
	);

	public static Vector2F operator * (Vector2F self, float other) => new(
		self.X * other,
		self.Y * other
	);

	public static Vector2F operator / (Vector2F self, Vector2F other) => new(
		self.X / other.X,
		self.Y / other.Y
	);

	public static Vector2F operator / (Vector2F self, float other) => new(
		self.X / other,
		self.Y / other
	);

	public static Vector2F operator %(Vector2F left, Vector2F other) => new(
		left.X % other.X,
		left.Y % other.Y
	);

	public static bool operator > (Vector2F self, Vector2F other)
		=> self.X > other.X && self.Y > other.Y;

	public static bool operator < (Vector2F self, Vector2F other)
		=> self.X < other.X && self.Y < other.Y;

	public static bool operator >= (Vector2F self, Vector2F other)
        => self.X >= other.X && self.Y >= other.Y;

	public static bool operator <= (Vector2F self, Vector2F other)
        => self.X <= other.X && self.Y <= other.Y;

	public static implicit operator Vector2F((float X, float Y) other)
		=> new(other.X, other.Y);

	public static explicit operator ValueTuple<float, float> (Vector2F self)
		=> new(self.X, self.Y);
}
