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
			if(b == 0) {
				Logger.Error("Can't divide by 0");
				return Zero;
			}

			return new Vector2(a.x / b, a.y / b);
		}

        public static bool operator ==(Vector2 a, Vector2 b) {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector2 a, Vector2 b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            return obj is Vector2 other && this == other;
        }

        public override int GetHashCode() {
            return HashCode.Combine(x, y);
        }

        public static bool operator >(Vector2 a, Vector2 b) {
			return a.SquareMagnitude() > b.SquareMagnitude();
		}

        public static bool operator <(Vector2 a, Vector2 b) {
            return a.SquareMagnitude() < b.SquareMagnitude();
        }

        public static bool operator >=(Vector2 a, Vector2 b) {
            return a.SquareMagnitude() >= b.SquareMagnitude();
        }

        public static bool operator <=(Vector2 a, Vector2 b) {
            return a.SquareMagnitude() <= b.SquareMagnitude();
        }

        public override string ToString() {
			return "(" + x + ", " + y + ")";
		}

		public float Magnitude() {
			return (float)Math.Sqrt(x * x + y * y);
		}

		public float SquareMagnitude() {
			return (x * x + y * y);
		}

		public Vector2 Normalized() {
			float sqMag = SquareMagnitude();

			if(sqMag == 0) {
				return Vector2.Zero;
			}

			float mag = 1f / (float)Math.Sqrt(sqMag);
			return new Vector2(x * mag, y * mag);
		}

		public static float DotProduct(Vector2 a, Vector2 b) {
			return (a.x * b.x + a.y * b.y);
		}

		public static float Distance(Vector2 a, Vector2 b) {
			return (a - b).Magnitude();
		}
	}
}