using KhelEngine.Mathf;

public class Rigidbody : Behaviour {
	private float precition = 0.01f;

	public bool isStatic = false;
	public bool useGravity = true;

	public override void Loop() {
		if(useGravity) {
			entity.transform.position += PhysicsManager.gravitationForce * Engine.deltaTime;
		}
	}

	public void Collided(Entity other, float combinedRadius) {
		Vector2 direction = entity.transform.position - other.transform.position;
		float distance = direction.Magnitude();
		float overlap = combinedRadius - distance;

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
}