using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public readonly record struct Vector3F(float X, float Y, float Z):
	IFloatingVector<Vector3F, float>,
	IMinMaxValue<Vector3F>,
	IUnaryPlusOperators<Vector3F, Vector3F>,
	IUnaryNegationOperators<Vector3F, Vector3F>,
	IAdditionOperators<Vector3F, Vector3F, Vector3F>,
	IAdditionOperators<Vector3F, float, Vector3F>,
	ISubtractionOperators<Vector3F, Vector3F, Vector3F>,
	ISubtractionOperators<Vector3F, float, Vector3F>,
	IMultiplyOperators<Vector3F, Vector3F, Vector3F>,
	IMultiplyOperators<Vector3F, float, Vector3F>,
	IDivisionOperators<Vector3F, Vector3F, Vector3F>,
	IDivisionOperators<Vector3F, float, Vector3F>,
	IComparisonOperators<Vector3F, Vector3F, bool>
{
	public static Vector3F MaxValue => new(float.MaxValue, float.MaxValue, float.MaxValue);
	public static Vector3F MinValue => new(float.MinValue, float.MinValue, float.MinValue);

	public float Length => float.Sqrt(
		X * X + Y * Y + Z * Z
	);

	public float this[int index] => index switch {
		0 => X,
		1 => Y,
		2 => Z,
		_ => throw new Exception()
	};

	public float this[char name] => name switch {
		'x' => X,
		'y' => Y,
		'z' => Z,
		_ => throw new Exception()
	};

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

	public static Vector3F Min(Vector3F first, Vector3F second)
		=> first < second
			? first
			: second;

	public static Vector3F Max(Vector3F first, Vector3F second) 
		=> first > second
			? first
			: second;

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

	public static Vector3F operator +(Vector3F value) => value;

	public static Vector3F operator -(Vector3F value) => new(
		-value.X, -value.Y, -value.Z
	);

	public static Vector3F operator +(Vector3F left, Vector3F right) => new(
		left.X + right.X,
		left.Y + right.Y,
		left.Z + right.Z
	);

	public static Vector3F operator +(Vector3F left, float right) => new(
		left.X + right,
		left.Y + right,
		left.Z + right
	);

	public static Vector3F operator -(Vector3F left, Vector3F right) => new(
		left.X - right.X,
		left.Y - right.Y,
		left.Z - right.Z
	);

	public static Vector3F operator -(Vector3F left, float right) => new(
		left.X - right,
		left.Y - right,
		left.Z - right
	);

	public static Vector3F operator *(Vector3F left, Vector3F right) => new(
		left.X * right.X,
		left.Y * right.Y,
		left.Z * right.Z
	);

	public static Vector3F operator *(Vector3F left, float right) => new(
		left.X * right,
		left.Y * right,
		left.Z * right
	);

	public static Vector3F operator /(Vector3F left, Vector3F right) => new(
		left.X / right.X,
		left.Y / right.Y,
		left.Z / right.Z
	);

	public static Vector3F operator /(Vector3F left, float right) => new(
		left.X / right,
		left.Y / right,
		left.Z / right
	);

	public static bool operator >(Vector3F left, Vector3F right)
		=> left.Length > right.Length;

	public static bool operator >=(Vector3F left, Vector3F right)
		=> left.Length >= right.Length;

	public static bool operator <(Vector3F left, Vector3F right)
		=> left.Length < right.Length;

	public static bool operator <=(Vector3F left, Vector3F right)
		=> left.Length <= right.Length;
	
	public static implicit operator Vector3F((float X, float Y, float Z) tuple)
		=> new(tuple.X, tuple.Y, tuple.Z);

	public static explicit operator ValueTuple<float, float, float>(Vector3F vector)
		=> new(vector.X, vector.Y, vector.Z);
}