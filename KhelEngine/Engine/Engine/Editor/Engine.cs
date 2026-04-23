using System.Diagnostics;

public static class Engine {
	private static Stopwatch stopwatch = Stopwatch.StartNew();
	private static long lastElapsedTime = stopwatch.ElapsedMilliseconds;

	private static float fixedTimer = 0f;
	private const float fixedStep = 0.016f;

	public static float deltaTime { get; private set; }

	public static void UpdateGame() {
		EngineLoopManager.UpdateAllEntityLoops();
		RunFixedLoop();
	}

	private static void RunFixedLoop() {
		long currentTime = stopwatch.ElapsedMilliseconds;
		deltaTime = (currentTime - lastElapsedTime) / 1000f;
		lastElapsedTime = currentTime;

		fixedTimer += deltaTime;

		while(fixedTimer >= fixedStep) {
			EngineFixedLoopManager.UpdateAllEntityFixedLoops();
			fixedTimer -= fixedStep;
		}
	}
}