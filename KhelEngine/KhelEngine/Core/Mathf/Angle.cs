using System;

namespace KhelEngine.Mathf {
	public static class Angle {
		public static float Degree2Radian(float degree) {
			return degree * ((float)Math.PI / 180f);
		}

		public static float Radian2Degree(float radian) {
			return radian * (180f / (float)Math.PI);
		}
	}
}
