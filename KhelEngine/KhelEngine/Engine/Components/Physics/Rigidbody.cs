using KhelEngine.Mathf;

public class Rigidbody : Behaviour {
	private float collisionSlop = 0.01f;

	public bool isStatic = false;
	public bool useGravity = true;

	public Vector2 velocity;

	private Collider collider;

    public override void Setup() {
        collider = entity.GetBehaviour<Collider>();

		if(collider == null) {
			Logger.Log("Error: can't find collider on entity: " + entity);
		}
    }

	public override void Loop() {
		if(useGravity) {
			velocity += PhysicsManager.gravitationForce;
		}
		
		entity.transform.position += velocity * Engine.deltaTime;
	}

	public void CirclesCollided(Entity other, float combinedRadius) {
		float overlap = 0;
		Vector2 direction = entity.transform.position - other.transform.position;
		
		float distance = direction.Magnitude();
		overlap = combinedRadius - distance;

		if(overlap > 0f) {
			Vector2 correction = direction.Normalized() * (overlap / 2f + collisionSlop);

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

    public void BoxesCollided(Entity other, Vector2 overlap) {
		Vector2 correction = new Vector2();

        if(overlap.x < overlap.y) {
			float direction = entity.transform.position.x < other.transform.position.x ? -1f : 1f;

			correction = new Vector2(direction * (overlap.x / 2 + collisionSlop / 2), 0f);
		}
		else {
            float direction = entity.transform.position.y < other.transform.position.y ? -1f : 1f;

            correction = new Vector2(0f, direction * (overlap.y / 2 + collisionSlop / 2));
        }

        if(!isStatic) {
            entity.transform.position += correction;
        }
		else {
			correction *= 2f;
		}

        if(other.GetBehaviour<Rigidbody>() != null) {
            if(!other.GetBehaviour<Rigidbody>().isStatic) {
                other.transform.position -= correction;
            }
			else {
                if(!isStatic) {
                    entity.transform.position += correction;
                }
            }
        }
    }

    public void AddForce(Vector2 force) {
		velocity += force;
	}
}