using TestGame.Api.Math.Vectors;

namespace TestGame.Game.Math;

public static class VectorExtensions {
	extension(Vector2I vector) {
		public Godot.Vector2I ToVector() => new(vector.X, vector.Y);

		public static Vector2I operator +(Vector2I left, Godot.Vector2I right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Vector2I operator -(Vector2I left, Godot.Vector2I right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Vector2I operator *(Vector2I left, Godot.Vector2I right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Vector2I operator /(Vector2I left, Godot.Vector2I right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
	}
	
	extension(Godot.Vector2I vector) {
		public Vector2I ToVector() => new(vector.X, vector.Y);

		public static Godot.Vector2I operator +(Godot.Vector2I left, Vector2I right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Godot.Vector2I operator -(Godot.Vector2I left, Vector2I right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Godot.Vector2I operator *(Godot.Vector2I left, Vector2I right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Godot.Vector2I operator /(Godot.Vector2I left, Vector2I right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
	}

	extension(Vector2F vector) {
		public Godot.Vector2 ToVector() => new(vector.X, vector.Y);

		public static Vector2F operator +(Vector2F left, Godot.Vector2 right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Vector2F operator -(Vector2F left, Godot.Vector2 right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Vector2F operator *(Vector2F left, Godot.Vector2 right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Vector2F operator /(Vector2F left, Godot.Vector2 right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
		
		public static Vector2F operator +(Vector2F left, Godot.Vector2I right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Vector2F operator -(Vector2F left, Godot.Vector2I right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Vector2F operator *(Vector2F left, Godot.Vector2I right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Vector2F operator /(Vector2F left, Godot.Vector2I right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
	}
	
	extension(Godot.Vector2 vector) {
		public Vector2F ToVector() => new(vector.X, vector.Y);

		public static Godot.Vector2 operator +(Godot.Vector2 left, Vector2F right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Godot.Vector2 operator -(Godot.Vector2 left, Vector2F right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Godot.Vector2 operator *(Godot.Vector2 left, Vector2F right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Godot.Vector2 operator /(Godot.Vector2 left, Vector2F right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
		
		public static Godot.Vector2 operator +(Godot.Vector2 left, Vector2I right) => new(
			left.X + right.X,
			left.Y + right.Y
		);
		
		public static Godot.Vector2 operator -(Godot.Vector2 left, Vector2I right) => new(
			left.X - right.X,
			left.Y - right.Y
		);
		
		public static Godot.Vector2 operator *(Godot.Vector2 left, Vector2I right) => new(
			left.X * right.X,
			left.Y * right.Y
		);
		
		public static Godot.Vector2 operator /(Godot.Vector2 left, Vector2I right) => new(
			left.X / right.X,
			left.Y / right.Y
		);
	}
}