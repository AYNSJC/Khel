using System.Collections.Generic;

public static class PhysicsManager {
	private static List<Collider> _colliderList = new List<Collider>();

	public static void Loop() {
		for(int i = 0; i < _colliderList.Count; i++) {
			for(int j = i + 1; j < _colliderList.Count; j++) {

			}
		}
	}

	public static void AddCollider(Collider collider) {
		_colliderList.Add(collider);
	}
}