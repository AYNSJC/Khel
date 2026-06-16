using KhelEngine.Mathf;
using System.Collections.Generic;

public static class PhysicsManager {
	private static List<Collider> _colliderList = new List<Collider>();

	public static void Loop() {
		for(int i = 0; i < _colliderList.Count; i++) {
			for(int j = i + 1; j < _colliderList.Count; j++) {
				if(_colliderList[i] is CircleCollider circleI && _colliderList[j] is CircleCollider circleJ) {
					CircleCollision(circleI, circleJ);
				}
			}
		}
	}

	public static void AddCollider(Collider collider) {
		_colliderList.Add(collider);
	}

	public static void RemoveCollider(Collider collider) { 
		_colliderList.Remove(collider);
	}

	private static void CircleCollision(CircleCollider i, CircleCollider j) { 
		if(Vector2.Distance(i.position(), j.position()) < i.radius + j.radius) {
			if(!i.wasInCollision || !j.wasInCollision) {
				i.wasInCollision = true;
				j.wasInCollision = true;

				i.CollisionEntered(j);
				j.CollisionEntered(i);
			}
		}
		else {
			if(i.wasInCollision || j.wasInCollision) {
				i.wasInCollision = false;
				j.wasInCollision = false;

				i.CollisionExited(j);
				j.CollisionExited(i);
			}
		}
	}
}