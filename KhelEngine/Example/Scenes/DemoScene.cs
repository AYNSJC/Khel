using KhelEngine.Mathf;

public class DemoScene : Scene {
	public override void Setup() {
		Entity entity = Instantiate.Create(new PlayerEntity(), Vector2.Zero, 0f);
		entities.Add(entity);
	}
}
