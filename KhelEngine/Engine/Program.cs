class Program {
	static void Main(string[] args) { 
		// All objects go through this: 
		Instantiator.CreateEntity<PlayerEntity>();

		// Update Game: 
		while(true) {
			Engine.UpdateGame();
		}
	}
}