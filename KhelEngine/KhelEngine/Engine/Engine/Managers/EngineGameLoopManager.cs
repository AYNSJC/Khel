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
			List<Behaviour> behaviourScriptList = entityList[i].behaviours;

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].Loop();
			}

			for(int j = 0; j < behaviourScriptList.Count; j++) {
				behaviourScriptList[j].Loop();
			}
		}
	}

	public static void AddEntity(Entity entity) {
		entityList.Add(entity);
	}

	public static void RemoveEntity(Entity entity) {
		entityList.Remove(entity);

		List<Script> entityScriptList = entity.scripts;
		List<Behaviour> behaviourScriptList = entity.behaviours;

		for(int j = 0; j < entityScriptList.Count; j++) {
			entityScriptList[j].Exit();
		}

		for(int j = 0; j < behaviourScriptList.Count; j++) {
			behaviourScriptList[j].Exit();
		}
	}

	public static void RefreshEntities(List<Entity> entities) {
		entityList = entities;
	}
}