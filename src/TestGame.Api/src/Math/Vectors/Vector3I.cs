using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public readonly record struct Vector3I(int X, int Y, int Z):
	IVector<Vector3I, int>,
	IMinMaxValue<Vector3I>,
	IUnaryPlusOperators<Vector3I, Vector3I>,
	IUnaryNegationOperators<Vector3I, Vector3I>,
	IAdditionOperators<Vector3I, Vector3I, Vector3I>,
	IAdditionOperators<Vector3I, int, Vector3I>,
	ISubtractionOperators<Vector3I, Vector3I, Vector3I>,
	ISubtractionOperators<Vector3I, int, Vector3I>,
	IMultiplyOperators<Vector3I, Vector3I, Vector3I>,
	IMultiplyOperators<Vector3I, int, Vector3I>,
	IDivisionOperators<Vector3I, Vector3I, Vector3I>,
	IDivisionOperators<Vector3I, int, Vector3I>,
	IComparisonOperators<Vector3I, Vector3I, bool>
{
	public static Vector3I MaxValue => new(int.MaxValue, int.MaxValue, int.MaxValue);
	public static Vector3I MinValue => new(int.MinValue, int.MinValue, int.MinValue);

	public float Length => float.Sqrt(
		X * X + Y * Y + Z * Z
	);

	public int this[int index] => index switch {
		0 => X,
		1 => Y,
		2 => Z,
		_ => throw new Exception()
	};

	public int this[char name] => name switch {
		'x' => X,
		'y' => Y,
		'z' => Z,
		_ => throw new Exception()
	};

	public static Vector3I Abs(Vector3I value) => new(
		int.Abs(value.X),
		int.Abs(value.Y),
		int.Abs(value.Z)
	);

	public static Vector3I Min(Vector3I first, Vector3I second)
		=> first < second
			? first
			: second;

	public static Vector3I Max(Vector3I first, Vector3I second) 
		=> first > second
			? first
			: second;

	public static Vector3I Clamp(Vector3I value, Vector3I min, Vector3I max) => new(
		int.Clamp(value.X, min.X, max.X),
		int.Clamp(value.Y, min.Y, max.Y),
		int.Clamp(value.Z, min.Z, max.Z)
	);

	public static Vector3I Clamp(Vector3I value, int min, int max) => new(
		int.Clamp(value.X, min, max),
		int.Clamp(value.Y, min, max),
		int.Clamp(value.Z, min, max)
	);

	public bool Equals(Vector3I other)
		=> X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

	public override int GetHashCode() => HashCode.Combine(X, Y, Z);

	public override string ToString() => $"Vector3I({X}, {Y}, {Z})";

	public static Vector3I operator +(Vector3I value) => value;

	public static Vector3I operator -(Vector3I value) => new(
		-value.X, -value.Y, -value.Z
	);

	public static Vector3I operator +(Vector3I left, Vector3I right) => new(
		left.X + right.X,
		left.Y + right.Y,
		left.Z + right.Z
	);

	public static Vector3I operator +(Vector3I left, int right) => new(
		left.X + right,
		left.Y + right,
		left.Z + right
	);

	public static Vector3I operator -(Vector3I left, Vector3I right) => new(
		left.X - right.X,
		left.Y - right.Y,
		left.Z - right.Z
	);

	public static Vector3I operator -(Vector3I left, int right) => new(
		left.X - right,
		left.Y - right,
		left.Z - right
	);

	public static Vector3I operator *(Vector3I left, Vector3I right) => new(
		left.X * right.X,
		left.Y * right.Y,
		left.Z * right.Z
	);

	public static Vector3I operator *(Vector3I left, int right) => new(
		left.X * right,
		left.Y * right,
		left.Z * right
	);

	public static Vector3I operator /(Vector3I left, Vector3I right) => new(
		left.X / right.X,
		left.Y / right.Y,
		left.Z / right.Z
	);

	public static Vector3I operator /(Vector3I left, int right) => new(
		left.X / right,
		left.Y / right,
		left.Z / right
	);

	public static bool operator >(Vector3I left, Vector3I right)
		=> left.Length > right.Length;

	public static bool operator >=(Vector3I left, Vector3I right)
		=> left.Length >= right.Length;

	public static bool operator <(Vector3I left, Vector3I right)
		=> left.Length < right.Length;

	public static bool operator <=(Vector3I left, Vector3I right)
		=> left.Length <= right.Length;
	
	public static implicit operator Vector3I((int X, int Y, int Z) tuple)
		=> new(tuple.X, tuple.Y, tuple.Z);

	public static explicit operator ValueTuple<int, int, int>(Vector3I vector)
		=> new(vector.X, vector.Y, vector.Z);
}