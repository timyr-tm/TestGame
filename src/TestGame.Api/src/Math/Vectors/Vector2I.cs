using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public readonly record struct Vector2I(int X, int Y):
	IVector<Vector2I, int>,
	IAdditionOperators<Vector2I, int, Vector2I>,
	ISubtractionOperators<Vector2I, int, Vector2I>,
	IMultiplyOperators<Vector2I, int, Vector2I>,
	IDivisionOperators<Vector2I, int, Vector2I>
{
	public static Vector2I MaxValue => new(int.MaxValue, int.MaxValue);
	public static Vector2I MinValue => new(int.MinValue, int.MinValue);

	public float Length => float.Sqrt(X * X + Y * Y);

	public int this[int index] => index switch {
		0 => X,
		1 => Y,
		var _ => throw new Exception()
	};

	public int this[char name] => name switch {
		'x' => X,
		'y' => Y,
		_ => throw new Exception()
	};

	public int CompareTo(Vector2I other) {
		if (this < other)
			return -1;
		return this > other ? 1 : 0;
	}

	public static Vector2I Abs(Vector2I value) => new(int.Abs(value.X), int.Abs(value.Y));

	public static Vector2I Min(Vector2I first, Vector2I second)
		=> first < second
			? first
			: second;

	public static Vector2I Max(Vector2I first, Vector2I second)
		=> first > second
			? first
			: second;

	public static Vector2I Clamp(Vector2I value, Vector2I min, Vector2I max) => new(
		int.Clamp(value.X, min.X, max.X),
		int.Clamp(value.Y, min.Y, max.Y)
	);

	public static Vector2I Clamp(Vector2I value, int min, int max) => new(
		int.Clamp(value.X, min, max),
		int.Clamp(value.Y, min, max)
	);

	public bool Equals(Vector2I other)
		=> X.Equals(other.X) && Y.Equals(other.Y);

	public override int GetHashCode() => HashCode.Combine(X, Y);

	public override string ToString() => $"Vector2I({X}, {Y})";
	
	public string ToString(string? format, IFormatProvider? provider)
		=> $"Vector2I({X.ToString(format, provider)}, {Y.ToString(format, provider)})";

	public static Vector2I operator + (Vector2I self) => self;

	public static Vector2I operator - (Vector2I self) => new(-self.X, -self.Y);

	public static Vector2I operator ++(Vector2I value) => new(value.X + 1, value.Y + 1);

	public static Vector2I operator --(Vector2I value) => new(value.X - 1, value.Y - 1);

	public static Vector2I operator + (Vector2I self, Vector2I vector) => new(
		self.X + vector.X,
		self.Y + vector.Y
	);

	public static Vector2I operator + (Vector2I self, int number) => new(
		self.X + number,
		self.Y + number
	);

	public static Vector2I operator - (Vector2I self, Vector2I vector) => new(
		self.X - vector.X,
		self.Y - vector.Y
	);

	public static Vector2I operator - (Vector2I self, int number) => new(
		self.X - number,
		self.Y - number
	);

	public static Vector2I operator * (Vector2I self, Vector2I vector) => new(
		self.X * vector.X,
		self.Y * vector.Y
	);

	public static Vector2I operator * (Vector2I self, int number) => new(
		self.X * number,
		self.Y * number
	);

	public static Vector2I operator / (Vector2I self, Vector2I vector) => new(
		self.X / vector.X,
		self.Y / vector.Y
	);

	public static Vector2I operator / (Vector2I self, int number) => new(
		self.X / number,
		self.Y / number
	);

	public static Vector2I operator %(Vector2I left, Vector2I right) => new(
		left.X % right.X,
		left.Y % right.Y
	);

	public static bool operator > (Vector2I self, Vector2I vector)
		=> self.Length > vector.Length;

	public static bool operator < (Vector2I self, Vector2I vector)
		=> self.Length < vector.Length;

	public static bool operator >= (Vector2I self, Vector2I vector) 
		=> self.Length >= vector.Length;

	public static bool operator <= (Vector2I self, Vector2I vector)
		=> self.Length <= vector.Length;

	public static implicit operator Vector2I((int X, int Y) tuple)
		=> new(tuple.X, tuple.Y);

	public static explicit operator ValueTuple<int, int>(Vector2I vector)
		=> new(vector.X, vector.Y);
}