namespace KhelEngine.Core.Math {
	public struct Vector2 {
		public float X;
		public float Y;

		public Vector2(float x, float y) {
			X = x;
			Y = y;
		}

		public static Vector2 Zero => new Vector2(0, 0);
		public static Vector2 One => new Vector2(1, 1);
	}
}