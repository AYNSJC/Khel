using KhelEngine.Mathf;

public class Rigidbody : Behaviour {
	private float precition = 0.01f;

	public void Collided(Entity other, float combinedRadius) {
		Vector2 direction = entity.transform.position - other.transform.position;
		float distance = direction.Magnitude();
		float overlap = combinedRadius - distance;

		if(overlap > 0f) {
			Vector2 correction = direction.Normalized() * (overlap / 2f + precition);
			entity.transform.position += correction;
			other.transform.position -= correction;
		}
	}
}