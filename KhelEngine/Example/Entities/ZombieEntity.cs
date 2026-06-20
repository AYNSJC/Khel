using KhelEngine.Mathf;

public class ZombieEntity : Entity {
	public ZombieEntity() {
		transfrom.position = new Vector2(5f, 0f);
		transfrom.rotation = 15f;
		transfrom.scale = Vector2.One;

		AddBehaviour(new CircleCollider());
		AddBehaviour(new Rigidbody());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = Vector2.One;
		imgRen.color = Color.Red;
		imgRen.rotationOffset = 90f;
		imgRen.fullImagePath = "F:\\Code\\C#\\Khel\\Khel\\KhelEngine\\Example\\Graphics\\hud_p1.png";

		AddScript(new ZombieScript());
	}
}
