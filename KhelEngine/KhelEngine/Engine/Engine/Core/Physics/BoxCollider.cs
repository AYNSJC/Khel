using KhelEngine.Mathf;

public class BoxCollider : Collider {
	public Vector2 size = Vector2.One;

	public Vector2 offset = Vector2.Zero;

	public override void Setup() {
		base.Setup();

		Vector2 finalSize = new Vector2(size.x * entity.transfrom.scale.x, size.y * entity.transfrom.scale.y);

		float sine = float.Sin(entity.transfrom.rotation);
		float cosine = float.Cos(entity.transfrom.rotation);

		Vector2 rotated;

		rotated.x = finalSize.x * cosine - finalSize.y * sine;
		rotated.y = finalSize.x * sine + finalSize.y * cosine;

		Vector2 pos = rotated + offset;

		pointsPositionList.Add(new Vector2(pos.x, pos.y));
		pointsPositionList.Add(new Vector2(1, 0));
		pointsPositionList.Add(new Vector2(1, 1));
		pointsPositionList.Add(new Vector2(0, 1));
	}
}