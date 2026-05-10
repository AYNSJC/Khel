using System.Diagnostics;

public static class Engine {
	private static Stopwatch stopwatch = Stopwatch.StartNew();
	private static long lastElapsedTime = stopwatch.ElapsedMilliseconds;

	private static float fixedTimer = 0f;
	private const float fixedStep = 0.016f;

	public static float deltaTime { get; private set; }

	private static OutputWindow window;

	private static Scene activeScene;

	public static void StartGame(IProjectSettings pS) {
		window = new OutputWindow(pS.Width, pS.Height, pS.ProjectName);

		SceneManager.UpdateSceneList(pS.workingScenes);
		SceneManager.SceneChanged += ChangeActiveScene;
	}

	public static void UpdateGame() {
		window.PollEvents();
		window.Render();
		EngineGameLoopManager.UpdateGame();
		RunFixedLoop();
	}

	private static void RunFixedLoop() {
		long currentTime = stopwatch.ElapsedMilliseconds;
		deltaTime = (currentTime - lastElapsedTime) / 1000f;
		lastElapsedTime = currentTime;

		fixedTimer += deltaTime;

		while(fixedTimer >= fixedStep) {
			EngineGameFixedLoopManager.UpdateGame();
			fixedTimer -= fixedStep;
		}
	}

	private static void ChangeActiveScene(Scene scene) {
		activeScene = scene;

		EngineGameLoopManager.RefreshEntities(scene.entities);
		EngineGameFixedLoopManager.RefreshEntities(scene.entities);
	}
}