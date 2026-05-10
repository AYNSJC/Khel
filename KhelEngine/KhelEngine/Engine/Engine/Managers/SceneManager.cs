using System;
using System.Collections.Generic;

public static class SceneManager {
	private static List<Scene> scenes = new List<Scene>();

	public static Action<Scene> SceneChanged;

	public static Scene LoadScene(int index) {
		scenes[index].isActive = true;
		scenes[index].Setup();
		SceneChanged?.Invoke(scenes[index]);
		DisableScenesExcept(scenes[index]);
		return scenes[index];
	}

	private static void DisableScenesExcept(Scene scene) {
		for(int i = 0; i < scenes.Count; i++) {
			if(scenes[i].isActive) {
				if(scenes[i] != scene) {
					scenes[i].isActive = false;
				}
			}
		}
	}

	public static void UpdateSceneList(List<Scene> scenesPS) {
		scenes = scenesPS;
	}
}