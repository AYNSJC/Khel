public class PlayerEntity : Entity {
	public PlayerEntity() {
		transfrom.position.x = 2f;
		transfrom.rotation = 15f;
		transfrom.scale.y = 1.25f;

		AddScript(new PlayerDebug());
	}
}
