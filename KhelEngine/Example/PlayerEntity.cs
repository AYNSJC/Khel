using KhelEngine.Mathf;

public class PlayerEntity : Entity {
	public PlayerEntity() {
		transfrom.position.x = 0f;
		transfrom.rotation = 15f;
		transfrom.scale = new Vector2(0.5f, 0.5f);

		AddScript(new PlayerScript());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.color = Color.Olive;
	}
}
