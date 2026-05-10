using System.Collections.Generic;

public static class EngineGameLoopManager {
	private static List<Entity> entityList = new List<Entity>();

	public static void UpdateGame() {
		UpdateInput();
		UpdateAllEntityLoops();
	}

	private static void UpdateInput() {
		Input.Update();
	}

	private static void UpdateAllEntityLoops() {
		for(int i = 0; i < entityList.Count; i++) {
			List<Script> entityScriptList = entityList[i].scripts;

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].Loop();
			}
		}
	}

	public static void AddEntity(Entity entity) {
		entityList.Add(entity);
	}

	public static void RefreshEntities(List<Entity> entities) {
		entityList = entities;
	}
}