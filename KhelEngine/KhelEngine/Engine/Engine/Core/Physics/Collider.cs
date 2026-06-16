using System;

public class Collider : Behaviour {
	public bool isTrigger;

	public bool wasInCollision;

	public event Action<Collider> OnCollisionEnter;
	public event Action<Collider> OnCollisionExit;

	public override void Setup() {
		PhysicsManager.AddCollider(this);
	}

	public override void Exit() {
		PhysicsManager.RemoveCollider(this);
	}

	public void CollisionEntered(Collider col) {
		 OnCollisionEnter?.Invoke(col);
	}

	public void CollisionExited(Collider col) {
		OnCollisionExit?.Invoke(col);
	}
}