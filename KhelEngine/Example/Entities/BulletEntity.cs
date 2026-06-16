using KhelEngine.Mathf;

public class BulletEntity : Entity {
	public BulletEntity() {
		transfrom.position = Vector2.Zero;
		transfrom.scale = Vector2.One;

		BulletScript bulletScript = (BulletScript)AddScript(new BulletScript());
		bulletScript.speed = 10f;
		bulletScript.deleteTimer = 2f;

		AddBehaviour(new CircleCollider());

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = new Vector2(0.5f, 0.5f);
		imgRen.color = Color.Yellow;
	}
}
