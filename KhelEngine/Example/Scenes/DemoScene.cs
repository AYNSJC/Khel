using KhelEngine.Mathf;

public class DemoScene : Scene {
	public override void Setup() {
		Instantiate.Create(new PlayerEntity(), Vector2.Zero, 0f, Vector2.One);
	}
}
