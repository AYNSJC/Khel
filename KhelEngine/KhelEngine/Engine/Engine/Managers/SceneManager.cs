using System;
using System.Collections.Generic;

public static class SceneManager {
	private static List<Scene> sceneList = new List<Scene>();

	public static Action<Scene> SceneChanged;

	public static Scene activeScene;

	public static Scene LoadScene(int index) {
		ExitCurrentActiveScene();

		if(index < 0 || index + 1 > sceneList.Count) {
			Logger.Error("Scene index out of bounds");
			return null;
		}

		activeScene = sceneList[index];

		activeScene.Setup();

		SceneChanged?.Invoke(activeScene);

		return activeScene;
	}

	private static void ExitCurrentActiveScene() {
		if(activeScene == null) return;

		activeScene.Exit();
		activeScene = null;
	}

	public static void UpdateSceneList(List<Scene> scenesPS) {
		sceneList = scenesPS;
	}
}