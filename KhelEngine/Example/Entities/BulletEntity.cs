using KhelEngine.Mathf;

public class BulletEntity : Entity {
	public BulletEntity() {
		transform.position = Vector2.Zero;
		transform.scale = Vector2.One;

		BulletScript bulletScript = (BulletScript)AddScript(new BulletScript());
		bulletScript.speed = 10f;
		bulletScript.deleteTimer = 2f;

		AddBehaviour(new CircleCollider());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.fullImagePath = "F:\\Code\\C#\\Khel\\Khel\\KhelEngine\\Example\\Graphics\\Particle.png";
		imgRen.scale = new Vector2(1f, 1f);
	}
}
