using KhelEngine.Mathf;
using System;

public class Transform : Behaviour {
	// Transform
	public Vector2 position = Vector2.Zero;
	public float rotation = 0f;
	public Vector2 scale = Vector2.One;

	public Vector2 Forward {
		get {
			Vector2 forward = new Vector2();
			forward.x = (float)Math.Cos(Angle.Degree2Radian(rotation));
			forward.y = (float)Math.Sin(Angle.Degree2Radian(rotation));

			return forward;
		}
	}

	public Vector2 Right {
		get {
			Vector2 right = new Vector2();
			right.x = -(float)Math.Sin(Angle.Degree2Radian(rotation));
			right.y = (float)Math.Cos(Angle.Degree2Radian(rotation));

			return right;
		}
	}

	public void LookTowards(Vector2 lookPosition) {
		Vector2 dir = lookPosition - position;

		Console.WriteLine(dir);

		float angle = Angle.Radian2Degree((float)Math.Atan2(dir.y, dir.x));

		Console.WriteLine(angle);

		rotation = angle;
	}
}