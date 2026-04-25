public class DemoScene : Scene {
	public override void Setup() {
		Entity entity = Instantiator.CreateEntity<PlayerEntity>();
		entities.Add(entity);
	}
}
