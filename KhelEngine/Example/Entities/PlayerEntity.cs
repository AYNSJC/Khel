using KhelEngine.Mathf;

public class PlayerEntity : Entity {
	public PlayerEntity() {
		transform.position = Vector2.Zero;
		transform.rotation = 15f;
		transform.scale = Vector2.One;

		AddScript(new PlayerScript());

		AddBehaviour(new CircleCollider());
		Rigidbody rb = (Rigidbody)AddBehaviour(new Rigidbody());
		rb.useGravity = false;

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = Vector2.One;
		imgRen.rotationOffset = 90f;
		imgRen.color = Color.Green;
		imgRen.fullImagePath = "F:\\Code\\C#\\Khel\\Khel\\KhelEngine\\Example\\Graphics\\hud_p1.png";
	}
}
