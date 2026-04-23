class Program {
	static void Main(string[] args) { 
		// All objects go through this: 
		PlayerEntity player = Instantiator.CreateEntity<PlayerEntity>();
		player.Setup();

		// Update Game: 
		while(true) {
			Engine.UpdateGame();
		}
	}
}