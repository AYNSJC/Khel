using KhelEngine.Mathf;
using System;
using System.Collections.Generic;

public class Transform : Behaviour {
	public Vector2 localPosition { get; set; } = Vector2.Zero;
	public float localRotation { get; set; } = 0f;
	public Vector2 localScale { get; set; } = Vector2.One;

	public Entity Parent { get; private set; }
	public List<Entity> Children { get; } = new List<Entity>();

	public Vector2 position {
		get {
			if(Parent == null)
				return localPosition;

			return Parent.transform.position + localPosition;
		}

		set {
			if(Parent == null) {
				localPosition = value;
				return;
			}

			localPosition = value - Parent.transform.position;
		}
	}

	public float rotation {
		get {
			if(Parent == null)
				return localRotation;

			return Parent.transform.rotation + localRotation;
		}

		set {
			if(Parent == null) {
				localRotation = value;
				return;
			}

			localRotation = value - Parent.transform.rotation;
		}
	}

	public Vector2 scale {
		get {
			if(Parent == null)
				return localScale;

			return new Vector2(Parent.transform.scale.x * localScale.x, Parent.transform.scale.y * localScale.y
			);
		}

		set {
			if(Parent == null) {
				localScale = value;
				return;
			}

			localScale = new Vector2(value.x / Parent.transform.scale.x, value.y / Parent.transform.scale.y);
		}
	}

	public Vector2 Forward {
		get {
			float radians = Angle.Degree2Radian(rotation);

			return new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians)).Normalized();
		}
	}

	public Vector2 Right {
		get {
			float radians = Angle.Degree2Radian(rotation);

			return new Vector2(-(float)Math.Sin(radians), (float)Math.Cos(radians)).Normalized();
		}
	}

	public void LookTowards(Vector2 lookPosition) {
		Vector2 dir = lookPosition - position;

		rotation = Angle.Radian2Degree((float)Math.Atan2(dir.y, dir.x));
	}

	public void SetParent(Entity parent) {
		if(Parent == parent)
			return;

		if(Parent != null)
			Parent.transform.Children.Remove(entity);

		Parent = parent;

		if(Parent != null)
			Parent.transform.Children.Add(entity);
	}
}