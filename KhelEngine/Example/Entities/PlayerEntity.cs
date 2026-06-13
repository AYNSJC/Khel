using KhelEngine.Mathf;

public class PlayerEntity : Entity {
	public PlayerEntity() {
		transfrom.position = Vector2.Zero;
		transfrom.rotation = 15f;
		transfrom.scale = Vector2.One;

		AddScript(new PlayerScript());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = Vector2.One;
		imgRen.fullImagePath = "F:\\Code\\C#\\Khel\\Khel\\KhelEngine\\Example\\Graphics\\hud_p1.png";
	}
}
