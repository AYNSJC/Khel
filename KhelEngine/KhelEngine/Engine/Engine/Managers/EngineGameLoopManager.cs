using System.Collections.Generic;

public static class EngineGameLoopManager {
	public static void UpdateGame() {
		UpdateInput();
		UpdateActiveSceneEntites();
	}

	private static void UpdateInput() {
		Input.Update();
	}

	private static void UpdateActiveSceneEntites() {
		SceneManager.activeScene.Loop();
	}
}