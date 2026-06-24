using System.Diagnostics;

public static class Engine {
	private static Stopwatch stopwatch = Stopwatch.StartNew();
	private static long lastElapsedTime = stopwatch.ElapsedMilliseconds;

	private static float fixedTimer = 0f;
	private const float fixedStep = 0.016f;

	public static float deltaTime { get; private set; }

	public static OutputWindow window;

	public static OutputWindow Windom => window;

	private static IProjectSettings projectSettings;

	public static IProjectSettings ProjectSettings => projectSettings;

	public static void StartGame(IProjectSettings pS) {
		projectSettings = pS;

		window = new OutputWindow(pS.Width, pS.Height, pS.ProjectName, pS.bgColor);

		SceneManager.UpdateSceneList(pS.workingScenes);
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
}