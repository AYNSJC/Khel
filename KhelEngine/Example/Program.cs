class Program {
	static void Main(string[] args) {
		// Intialize Game
		Engine.StartGame(new ExampleProjectSettings());

		// Load Scene
		SceneManager.LoadScene(new DemoScene());

		// Update Game: 
		while(true) {
			Engine.UpdateGame();
		}
	}
}