
class Program {
	public static void Main(string[] args) { 
		// All objects go through this:
		PlayerEntity player = Instantiator.CreateEntity<PlayerEntity>();
		player.scripts.Add(new PlayerDebug());

		// After all scripts are added:
		player.AssignScripts();
		player.Setup();
	}
}