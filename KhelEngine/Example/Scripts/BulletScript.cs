public class BulletScript : Script {
	public float speed;

	public float deleteTimer;
	private float currentTimer;

	public override void Enter() {
		currentTimer = deleteTimer;

		CircleCollider circleCollider = entity.GetBehaviour<CircleCollider>();

		circleCollider.OnCollisionEnter += OnCollisionEnter;
	}

	public override void Loop() {
		entity.transform.position += entity.transform.Forward * (speed * Engine.deltaTime);
		DeleteAfterTime();
	}

	private void OnCollisionEnter(Collider col) {
		if(col.entity is ZombieEntity) {
			Deinstantiate.Delete(col.entity);
		}
	}

	private void DeleteAfterTime() {
		if(currentTimer > 0) {
			currentTimer -= Engine.deltaTime;
		} 
		else {
			Deinstantiate.Delete(entity);
		}
	}
}
