class Program {
	static void Main(string[] args) {
		// Load Scene
		SceneManager.LoadScene(new DemoScene());

		// Update Game: 
		while(true) {
			Engine.UpdateGame();
		}
	}
}