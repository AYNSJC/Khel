using System.Collections.Generic;

public class Entity {
	public Transform transfrom = new Transform();
	public List<Behaviour> behaviours = new List<Behaviour>();

	public void AddBehaviour(Behaviour behaviour) { 
		behaviours.Add(behaviour);
	}

	public void Setup() {
		AddBehaviour(transfrom);
		transfrom.entity = this;

		LaunchBehaviours();
	}

	private void LaunchBehaviours() {
		for(int i = 0; i < behaviours.Count; i++) {
			behaviours[i].Enter();
		}
	}
}
