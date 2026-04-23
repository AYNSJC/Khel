using System.Collections.Generic;

public static class EngineLoopManager {
	private static List<Entity> entityList = new List<Entity>();

	public static void UpdateAllEntityLoops() {
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
}