public class Player : Entity {
	public Player() {
		transfrom.position.X = 2f;
		transfrom.rotation = 15f;
		transfrom.scale.Y = 1.25f;
	}

	public override void Enter() {
		transfrom.position.X = 3f;
	}
}
