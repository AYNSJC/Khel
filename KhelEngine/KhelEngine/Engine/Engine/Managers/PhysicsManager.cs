using KhelEngine.Mathf;
using System;
using System.Collections.Generic;

public static class PhysicsManager {
	private static List<Collider> _colliderList = new List<Collider>();

	public static Vector2 gravitationForce = new Vector2(0f, -9.81f);

	public static void Loop() {
		for(int i = 0; i < _colliderList.Count; i++) {
			for(int j = i + 1; j < _colliderList.Count; j++) {
				if(_colliderList[i] is CircleCollider circleI && _colliderList[j] is CircleCollider circleJ) {
					CircleCollision(circleI, circleJ);
				}
                else if(_colliderList[i] is BoxCollider boxI && _colliderList[j] is BoxCollider boxJ) {
                    BoxCollision(boxI, boxJ);
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

				i.entity.GetBehaviour<Rigidbody>()?.Collided(j.entity, i.radius + j.radius);
				j.entity.GetBehaviour<Rigidbody>()?.Collided(i.entity, i.radius + j.radius);
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

    private static void BoxCollision(BoxCollider i, BoxCollider j) {
        float overlapX = (i.size.x / 2f + j.size.x / 2f) - MathF.Abs(i.entity.transform.position.x - j.entity.transform.position.x);
        float overlapY = (i.size.y / 2f + j.size.y / 2f) - MathF.Abs(i.entity.transform.position.y - j.entity.transform.position.y);

		Vector2 overlap = new Vector2(overlapX, overlapY);

        if(overlap > Vector2.Zero) {
            if(!i.wasInCollision || !j.wasInCollision) {
                i.wasInCollision = true;
                j.wasInCollision = true;

                i.CollisionEntered(j);
                j.CollisionEntered(i);

                i.entity.GetBehaviour<Rigidbody>()?.Collided(j.entity, Overlap: overlap.Magnitude());
                j.entity.GetBehaviour<Rigidbody>()?.Collided(i.entity, Overlap: overlap.Magnitude());
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