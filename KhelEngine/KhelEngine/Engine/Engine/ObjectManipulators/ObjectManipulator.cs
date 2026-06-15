using System;
using System.Collections.Generic;

public static class ObjectManipulator {
	public static Entity CreateEntity(Type type) {
		Entity entity = (Entity)Activator.CreateInstance(type);
		SetUpEntity(entity);
		entity.Setup();

		return entity;
	}

	public static void DeleteEntity(Entity entity) {
		RemoveEntity(entity);
	}

	private static void SetUpEntity(Entity entity) {
		SceneManager.activeScene.entityList.Add(entity);
	}

	private static void RemoveEntity(Entity entity) {
		SceneManager.activeScene.entityList.Remove(entity);

		List<Script> entityScriptList = entity.scripts;
		List<Behaviour> behaviourScriptList = entity.behaviours;

		for(int j = 0; j < entityScriptList.Count; j++) {
			entityScriptList[j].Exit();
		}

		for(int j = 0; j < behaviourScriptList.Count; j++) {
			behaviourScriptList[j].Exit();
		}
	}
}