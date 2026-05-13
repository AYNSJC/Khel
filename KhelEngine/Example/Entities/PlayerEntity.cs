using KhelEngine.Mathf;

public class PlayerEntity : Entity {
	public PlayerEntity() {
		transfrom.position.x = 0f;
		transfrom.rotation = 15f;
		transfrom.scale = Vector2.One;

		AddScript(new PlayerScript());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = new Vector2(0.25f, 0.25f);
		imgRen.color = Color.Red;
	}
}
