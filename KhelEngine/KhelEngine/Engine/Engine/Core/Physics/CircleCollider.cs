using KhelEngine.Mathf;

public class CircleCollider : Collider {
	public float radius = 0.5f;
	public Vector2 offset = Vector2.Zero;

	public Vector2 position() {
		return entity.transfrom.position + offset;
	}
}