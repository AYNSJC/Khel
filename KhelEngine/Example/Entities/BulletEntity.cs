using KhelEngine.Mathf;

public class BulletEntity : Entity {
	public BulletEntity() {
		transfrom.position = Vector2.Zero;
		transfrom.scale = Vector2.One;

		BullletScript bulletScript = (BullletScript)AddScript(new BullletScript());
		bulletScript.speed = 10f;
		bulletScript.deleteTimer = 2f;

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = new Vector2(0.5f, 0.5f);
		imgRen.color = Color.Yellow;
	}
}
