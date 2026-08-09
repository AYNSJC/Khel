using KhelEngine.Mathf;

public class Rigidbody : Behaviour {
	private float precition = 0.01f;

	public bool isStatic = false;
	public bool useGravity = true;

	public Vector2 velocity;

	public override void Loop() {
		if(useGravity) {
			velocity += PhysicsManager.gravitationForce;
		}
		
		entity.transform.position += velocity * Engine.deltaTime;
	}

	public void Collided(Entity other, float combinedRadius = 0, float Overlap = 0) {
		float overlap = Overlap;
		Vector2 direction = entity.transform.position - other.transform.position;

        if(overlap == 0) {
			float distance = direction.Magnitude();
			overlap = combinedRadius - distance;
		}

		if(overlap > 0f) {
			Vector2 correction = direction.Normalized() * (overlap / 2f + precition);

			if(!isStatic) {
				entity.transform.position += correction;
			}

			if(other.GetBehaviour<Rigidbody>() != null) {
				if(!other.GetBehaviour<Rigidbody>().isStatic) {
					other.transform.position -= correction;
				}
			}
		}
	}

	public void AddForce(Vector2 force) {
		velocity += force;
	}
}