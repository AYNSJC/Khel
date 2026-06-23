using KhelEngine.Mathf;
using System;

public static class Instantiate {
	public static Entity Create(Entity entity, Vector2 position, float rotation, Vector2 scale) {
		Type type = entity.GetType();

		Entity spawnedEntity = ObjectManipulator.CreateEntity(type);

		spawnedEntity.transform.position = position;
		spawnedEntity.transform.rotation = rotation;
		spawnedEntity.transform.scale = scale;

		return spawnedEntity;
	}
}