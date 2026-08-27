using System;
using System.Collections.Generic;

public static class SceneManager {
	private static List<Scene> sceneList = new List<Scene>();

	public static Action<Scene> SceneChanged;

	public static Scene activeScene;

	public static Scene LoadScene(int index) {
		if(index < 0 || index + 1 > sceneList.Count) {
			Logger.Error("Scene index out of bounds");
			return null;
		}

		ExitCurrentActiveScene(index);

		activeScene = sceneList[index];

		activeScene.Setup();

		SceneChanged?.Invoke(activeScene);

		return activeScene;
	}

	private static void ExitCurrentActiveScene(int i) {
		if(activeScene == null) return;

		activeScene.Exit();
		activeScene.DeleteAllEntities();
		activeScene = null;
	}

	public static void UpdateSceneList(List<Scene> scenesPS) {
		sceneList = scenesPS;
	}
}