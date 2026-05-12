using System.Collections.Generic;

public class Entity {
	public Transform transfrom = new Transform();
	public List<Behaviour> behaviours = new List<Behaviour>();
	public List<Script> scripts = new List<Script>();

	public Behaviour AddBehaviour(Behaviour behaviour) { 
		behaviours.Add(behaviour);

		behaviour.entity = this;

		return behaviour;
	}

	public Script AddScript(Script script) {
		scripts.Add(script);

		script.entity = this;

		return script;
	}

	public void Setup() {
		AddBehaviour(transfrom);
		transfrom.entity = this;

		LaunchBehaviours();
		LaunchScripts();
	}

	private void LaunchBehaviours() {
		for(int i = 0; i < behaviours.Count; i++) {
			behaviours[i].Setup();
			behaviours[i].Enter();
		}
	}

	private void LaunchScripts() {
		for(int i = 0; i < scripts.Count; i++) {
			scripts[i].Setup();
			scripts[i].Enter();
		}
	}
}
