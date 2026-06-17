using KhelEngine.Mathf;

public class ZombieScript : Script {
	private Entity playerEntity;

	public override void Enter() {
		playerEntity = Entity.FindFirstEntityOfType<PlayerEntity>();
	}

	public override void Loop() {
		entity.transfrom.LookTowards(playerEntity.transfrom.position);

		entity.transfrom.position += entity.transfrom.Forward * 1f * Engine.deltaTime;
	}
}
