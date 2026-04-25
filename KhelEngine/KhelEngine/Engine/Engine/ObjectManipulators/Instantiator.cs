using System.Collections.Generic;

public static class Instantiator {
	public static List<Entity> entities = new List<Entity>();

	public static T CreateEntity<T>() where T : Entity, new() {
		T entity = new T();
		entities.Add(entity);
		SetUpEntity(entity);
		entity.Setup();
		return entity;
	}

	private static void SetUpEntity(Entity entity) {
		EngineGameLoopManager.AddEntity(entity);
		EngineGameFixedLoopManager.AddEntity(entity);
	}
}