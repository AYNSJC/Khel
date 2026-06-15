using KhelEngine.Mathf;
using System;

public static class Instantiate {
	public static Entity Create(Entity entity, Vector2 position, float rotation, Vector2 scale) {
		Type type = entity.GetType();

		Entity spawnedEntity = ObjectManipulator.CreateEntity(type);

		spawnedEntity.transfrom.position = position;
		spawnedEntity.transfrom.rotation = rotation;
		spawnedEntity.transfrom.scale = scale;

		return spawnedEntity;
	}
}