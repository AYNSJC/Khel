using System.Collections.Generic;

public static class SceneManager {
	private static List<Scene> scenes = new List<Scene>();

	public static Scene LoadScene(Scene scene) {
		scene.isActive = true;
		scene.Setup();
		DisableScenesExcept(scene);
		return scene;
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
}