namespace KhelEngine.Core.Math {
	public struct Vector2 {
		public float x;
		public float y;

		public Vector2(float x, float y) {
			this.x = x;
			this.y = y;
		}

		public static Vector2 Zero => new Vector2(0, 0);
		public static Vector2 One => new Vector2(1, 1);
	}
}