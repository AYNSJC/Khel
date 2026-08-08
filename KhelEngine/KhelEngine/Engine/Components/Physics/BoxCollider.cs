using KhelEngine.Mathf;

public class BoxCollider : Collider {
    public float xSize = 1f;
    public float ySize = 1f;
    public Vector2 offset = Vector2.Zero;

    public Vector2 position() {
        return entity.transform.position + offset;
    }
}