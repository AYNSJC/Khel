using System;
using System.Collections.Generic;

public static class ObjectManipulator {
	public static List<Entity> entities = new List<Entity>();

	public static Entity CreateEntity(Type type) {
		Entity entity = (Entity)Activator.CreateInstance(type);

		entities.Add(entity);
		SetUpEntity(entity);
		entity.Setup();

		return entity;
	}

	public static void DeleteEntity(Entity entity) {
		entities.Remove(entity);
		RemoveEntity(entity);
	}

	private static void SetUpEntity(Entity entity) {
		EngineGameLoopManager.AddEntity(entity);
		EngineGameFixedLoopManager.AddEntity(entity);
	}

	private static void RemoveEntity(Entity entity) {
		EngineGameLoopManager.RemoveEntity(entity);
		EngineGameFixedLoopManager.RemoveEntity(entity);
	}
}