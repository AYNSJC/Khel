using System.Collections.Generic;

public static class EngineGameFixedLoopManager {
	private static List<Entity> entityList = new List<Entity>();

	public static void UpdateGame() {
		UpdateAllEntityFixedLoops();
	}

	private static void UpdateAllEntityFixedLoops() {
		for(int i = 0; i < entityList.Count; i++) {
			List<Script> entityScriptList = entityList[i].scripts;

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].FixedLoop();
			}
		}
	}

	public static void AddEntity(Entity entity) {
		entityList.Add(entity);
	}
}