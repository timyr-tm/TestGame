using System.Diagnostics.CodeAnalysis;

namespace TestGame.Api.Math.Vectors;

public struct Vector2F(float x, float y) : IVector2<Vector2F, float> {
	public static Vector2F MaxValue => new(float.MaxValue, float.MaxValue);
	public static Vector2F MinValue => new(float.MinValue, float.MinValue);
	
	public float X { get; set; } = x;
	public float Y { get; set; } = y;


	[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
	public bool Equals(Tuple<float, float>? other) => X == other?.Item1 && Y == other.Item2;

	public bool Equals(Vector2F other) => X.Equals(other.X) && Y.Equals(other.Y);
	
	[SuppressMessage("ReSharper", "FunctionRecursiveOnAllPaths")]
	public override bool Equals(object? obj) => Equals((Vector2F?) obj) || Equals((Tuple<float, float>?) obj);

	[SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
	public override int GetHashCode() {
		return HashCode.Combine(X, Y);
	}

	public override string ToString() => $"{nameof(Vector2F)}({X}, {Y})";

	public float Length() => float.Sqrt(float.Pow(X, 2) + float.Pow(Y, 2));

	public float LengthSquared() => float.Pow(X, 2) + float.Pow(Y, 2);

	public Vector2F Abs() => new(float.Abs(X), float.Abs(Y));

	public Vector2F Clamp(Vector2F min, Vector2F max) => new(
		float.Clamp(X, min.X, max.X),
		float.Clamp(Y, min.Y, max.Y)
	);

	public Vector2F Clamp(float min, float max) => new(
		float.Clamp(X, min, max),
		float.Clamp(Y, min, max)
	);

	public float DistanceTo(Vector2F vector) => float.Sqrt(
		float.Pow(X - vector.X, 2) + float.Pow(Y - vector.Y, 2) 
	);

	public void operator += (Vector2F vector) {
		X += vector.X;
		Y += vector.Y;
	}

	public void operator += (float number) {
		X += number;
		Y += number;
	}

	public void operator -= (Vector2F vector) {
		X -= vector.X;
		Y -= vector.Y;
	}

	public void operator -= (float number) {
		X -= number;
		Y -= number;
	}

	public void operator *= (Vector2F vector) {
		X *= vector.X;
		Y *= vector.Y;
	}

	public void operator *= (float number) {
		X *= number;
		Y *= number;
	}

	public void operator /= (Vector2F vector) {
		X /= vector.X;
		Y /= vector.Y;
	}

	public void operator /= (float number) {
		X /= number;
		Y /= number;
	}

	public static Vector2F operator + (Vector2F left, Vector2F right) => new(
		left.X + right.X,
		left.Y + right.Y
	);

	public static Vector2F operator + (Vector2F left, float right) => new(
		left.X + right,
		left.Y + right
	);

	public static Vector2F operator - (Vector2F left, Vector2F right) => new(
		left.X - right.X,
		left.Y - right.Y
	);

	public static Vector2F operator - (Vector2F left, float right) => new(
		left.X - right,
		left.Y - right
	);

	public static Vector2F operator * (Vector2F left, Vector2F right) => new(
		left.X * right.X,
		left.Y * right.Y
	);

	public static Vector2F operator * (Vector2F left, float right) => new(
		left.X * right,
		left.Y * right
	);

	public static Vector2F operator / (Vector2F left, Vector2F right) => new(
		left.X / right.X,
		left.Y / right.Y
	);

	public static Vector2F operator / (Vector2F left, float right) => new(
		left.X / right,
		left.Y / right
	);

	public static Vector2F operator + (Vector2F vector) => vector;

	public static Vector2F operator - (Vector2F vector) => new(
		-vector.X,
		-vector.Y
	);

	public static Vector2F operator ++ (Vector2F vector) => new(
		vector.X + 1,
		vector.Y + 1
	);

	public static Vector2F operator -- (Vector2F vector) => new(
		vector.X - 1,
		vector.Y - 1
	);

	public static bool operator == (Vector2F left, Vector2F right) => left.Equals(right);

	public static bool operator != (Vector2F left, Vector2F right) => !left.Equals(right);

	public static bool operator > (Vector2F left, Vector2F right) => left.X > right.X && left.Y > right.Y;

	public static bool operator < (Vector2F left, Vector2F right) => left.X < right.X && left.Y < right.Y;

	public static bool operator >= (Vector2F left, Vector2F right) => left.X >= right.X && left.Y >= right.Y;

	public static bool operator <= (Vector2F left, Vector2F right) => left.X <= right.X && left.Y <= right.Y;

	public static implicit operator Vector2F ((float X, float Y) tuple) => new(tuple.X, tuple.Y);

	public static explicit operator Tuple<float, float> (Vector2F vector) => new(vector.X, vector.Y);
}