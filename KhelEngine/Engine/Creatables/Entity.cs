using System.Collections.Generic;

public class Entity {
	public Transform transfrom = new Transform();
	public List<Behaviour> behaviours = new List<Behaviour>();
	public List<Script> scripts = new List<Script>();

	public void AddBehaviour(Behaviour behaviour) { 
		behaviours.Add(behaviour);
	}

	public void Setup() {
		AddBehaviour(transfrom);
		transfrom.entity = this;

		LaunchBehaviours();
		LaunchScripts();
	}

	private void LaunchBehaviours() {
		for(int i = 0; i < behaviours.Count; i++) {
			behaviours[i].Enter();
		}
	}

	private void LaunchScripts() {
		for(int i = 0; i < scripts.Count; i++) {
			scripts[i].Setup();
			scripts[i].Enter();
		}
	}

	public void AssignScripts() {
		for(int i = 0; i < scripts.Count; i++) {
			scripts[i].entity = this;
		}
	}

	public void AddScript(Script script) {
		scripts.Add(script);
		AssignScripts();
	}
}
