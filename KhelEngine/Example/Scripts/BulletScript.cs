public class BullletScript : Script {
	public float speed;

	public float deleteTimer;
	private float currentTimer;

	public override void Enter() {
		currentTimer = deleteTimer;
	}

	public override void Loop() {
		entity.transfrom.position += entity.transfrom.Forward * (speed * Engine.deltaTime);
		DeleteAfterTime();
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
