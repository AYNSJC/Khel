using KhelEngine.Mathf;
using System.Collections.Generic;

public class Collider : Behaviour {
	public List<Vector2> pointsPositionList;

	public bool isTrigger;

	public bool useGravitity;

	public bool isStatic;

	protected void InContactEnter(Collider other) { }
	protected void InContactExit(Collider other) { }

	public override void Setup() {
		PhysicsManager.AddCollider(this);
	}
}