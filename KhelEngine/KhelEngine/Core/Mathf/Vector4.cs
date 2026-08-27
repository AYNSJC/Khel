using System;

namespace KhelEngine.Mathf {
	public struct Vector4 {
		public float x;
		public float y;
		public float z;
		public float w;

		public Vector4(float x, float y, float z, float w) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static Vector4 Zero => new Vector4(0, 0, 0, 0);
		public static Vector4 One => new Vector4(1, 1, 1, 1);

		public static Vector4 operator +(Vector4 v1, Vector4 v2) {
			return new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
		}

		public static Vector4 operator -(Vector4 v1, Vector4 v2) {
			return new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
		}

		public static Vector4 operator *(Vector4 a, float b) {
			return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
		}

		public static Vector4 operator *(float a, Vector4 b) {
			return a * b;
		}

		public static Vector4 operator /(Vector4 a, float b) {
			if(b == 0) {
				Logger.Error("Can't divide by 0");
				return Zero;
			}

			return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
		}

		public static bool operator ==(Vector4 a, Vector4 b) {
			return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
		}

		public static bool operator !=(Vector4 a, Vector4 b) {
			return !(a == b);
		}

		public override bool Equals(object obj) {
			return obj is Vector4 other && this == other;
		}

		public override int GetHashCode() {
			return HashCode.Combine(x, y, z, w);
		}

		public static bool operator >(Vector4 a, Vector4 b) {
			return a.SquareMagnitude() > b.SquareMagnitude();
		}

		public static bool operator <(Vector4 a, Vector4 b) {
			return a.SquareMagnitude() < b.SquareMagnitude();
		}

		public static bool operator >=(Vector4 a, Vector4 b) {
			return a.SquareMagnitude() >= b.SquareMagnitude();
		}

		public static bool operator <=(Vector4 a, Vector4 b) {
			return a.SquareMagnitude() <= b.SquareMagnitude();
		}

		public float Magnitude() {
			return (float)Math.Sqrt(SquareMagnitude());
		}

		public float SquareMagnitude() {
			return (x * x + y * y + z * z + w * w);
		}

		public Vector4 Normalized() {
			float sqMag = SquareMagnitude();

			if(sqMag == 0) {
				return Vector4.Zero;
			}

			float mag = 1f / (float)Math.Sqrt(sqMag);
			return new Vector4(x * mag, y * mag, z * mag, w * mag);
		}

		public override string ToString() {
			return "(" + x + ", " + y + ", " + z + ", " + w + ")";
		}
	}
}