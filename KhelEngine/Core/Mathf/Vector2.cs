using System;

namespace KhelEngine.Mathf {
	public struct Vector2 {
		public float x;
		public float y;

		public Vector2(float x, float y) {
			this.x = x;
			this.y = y;
		}

		public static Vector2 Zero => new Vector2(0, 0);
		public static Vector2 One => new Vector2(1, 1);

		public static Vector2 operator +(Vector2 v1, Vector2 v2) {
			return new Vector2(v1.x + v2.x, v1.y + v2.y);
		}

		public static Vector2 operator -(Vector2 v1, Vector2 v2) {
			return new Vector2(v1.x - v2.x, v1.y - v2.y);
		}

		public static Vector2 operator *(Vector2 a, float b) {
			return new Vector2(a.x * b, a.y * b);
		}

		public static Vector2 operator *(float a, Vector2 b) {
			return a * b;
		}

		public static Vector2 operator /(Vector2 a, float b) {
			return new Vector2(a.x / b, a.y / b);
		}

		public float Magnitude() {
			return (float)Math.Sqrt(x * x + y * y);
		}

		public float SquareMagnitude() {
			return (x * x + y * y);
		}
	}
}