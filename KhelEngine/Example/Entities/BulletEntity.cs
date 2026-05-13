using KhelEngine.Mathf;

public class BulletEntity : Entity {
	public BulletEntity() { 
		BullletScript bulletScript = (BullletScript)AddScript(new BullletScript());
		bulletScript.speed = 3f;
		bulletScript.deleteTimer = 2f;

		ImageRenderer imgRen = (ImageRenderer)AddBehaviour(new ImageRenderer());
		imgRen.scale = new Vector2(0.05f, 0.05f);
		imgRen.color = Color.Yellow;
	}
}
