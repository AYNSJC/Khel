using KhelEngine.Mathf;

public class BoxCollider : Collider {
    public Vector2 size = Vector2.One;
    public Vector2 offset = Vector2.Zero;

    public Vector2 position() {
        return entity.transform.position + offset;
    }
}