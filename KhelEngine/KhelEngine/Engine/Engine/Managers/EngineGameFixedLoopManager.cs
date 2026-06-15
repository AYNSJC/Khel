using System.Collections.Generic;

public static class EngineGameFixedLoopManager {
	public static void UpdateGame() {
		UpdateAllEntityFixedLoops();

		PhysicsManager.Loop();
	}

	private static void UpdateAllEntityFixedLoops() {
		SceneManager.activeScene.FixedLoop();
	}
}