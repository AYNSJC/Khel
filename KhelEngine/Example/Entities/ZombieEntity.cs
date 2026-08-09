using KhelEngine.Mathf;

public class ZombieEntity : Entity {
	public ZombieEntity() {
		transform.position = new Vector2(5f, 0f);
		transform.rotation = 15f;
		transform.scale = Vector2.One;

		AddBehaviour(new BoxCollider());
		Rigidbody rb = (Rigidbody)AddBehaviour(new Rigidbody());
		rb.useGravity = false;

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = Vector2.One;
		imgRen.color = Color.Red;
		imgRen.rotationOffset = 90f;
		imgRen.fullImagePath = "D:\\Code\\C#\\Khel\\KhelEngine\\Example\\Graphics\\hud_p1.png";

		AddScript(new ZombieScript());
	}
}
