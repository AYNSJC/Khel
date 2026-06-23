using KhelEngine.Mathf;

public class ZombieScript : Script {
	private Entity playerEntity;

	public override void Enter() {
		playerEntity = Entity.FindFirstEntityOfType<PlayerEntity>();
	}

	public override void Loop() {
		entity.transform.LookTowards(playerEntity.transform.position);

		entity.transform.position += entity.transform.Forward * 1f * Engine.deltaTime;
	}
}
