public class PlayerEntity : Entity {
	public PlayerEntity() {
		transfrom.position.x = 0f;
		transfrom.rotation = 15f;
		transfrom.scale.y = 1.25f;

		AddScript(new PlayerScript());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.color = Color.Red;
	}
}
