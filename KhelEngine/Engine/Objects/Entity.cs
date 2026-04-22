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
	}
}
