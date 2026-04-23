class Program {
	public static void Main(string[] args) { 
		// All objects go through this:
		PlayerEntity player = Instantiator.CreateEntity<PlayerEntity>();
		player.Setup();
	}
}