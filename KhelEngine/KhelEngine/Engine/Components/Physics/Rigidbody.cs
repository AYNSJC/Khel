using KhelEngine.Mathf;

public class Rigidbody : Behaviour {
	public void Collided(Entity other) {
		Vector2 objectsDirection = other.transfrom.position - entity.transfrom.position;

		entity.transfrom.position -= objectsDirection * 100f * Engine.deltaTime;
	}
}