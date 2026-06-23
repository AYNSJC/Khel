using KhelEngine.Mathf;

public class DemoScene : Scene {
	public override void Setup() {
		Instantiate.Create(new PlayerEntity(), Vector2.Zero, 0f, Vector2.One);
		Instantiate.Create(new ZombieEntity(), new Vector2(5f, 0f), 0f, Vector2.One);
		Instantiate.Create(new ZombieEntity(), new Vector2(-5f, 0f), 0f, Vector2.One);
	}
}
