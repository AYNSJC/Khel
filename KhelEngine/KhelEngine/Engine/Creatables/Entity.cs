using System.Collections.Generic;

public class Entity {
	public Transform transfrom = new Transform();
	public List<Behaviour> behaviourList = new List<Behaviour>();
	public List<Script> scriptList = new List<Script>();

	public Behaviour AddBehaviour(Behaviour behaviour) { 
		behaviourList.Add(behaviour);

		behaviour.entity = this;

		return behaviour;
	}

	public Script AddScript(Script script) {
		scriptList.Add(script);

		script.entity = this;

		return script;
	}

	public T GetBehaviour<T>() where T : Behaviour {
		for(int i = 0; i < behaviourList.Count; i++) {
			if(behaviourList[i] is T behaviour) {
				return behaviour;
			}
		}

		return null;
	}

	public T GetScript<T>() where T : Script {
		for(int i = 0; i < scriptList.Count; i++) {
			if(scriptList[i] is T script) {
				return script;
			}
		}

		return null;
	}

	public void Setup() {
		AddBehaviour(transfrom);
		transfrom.entity = this;

		LaunchBehaviours();
		LaunchScripts();
	}

	private void LaunchBehaviours() {
		for(int i = 0; i < behaviourList.Count; i++) {
			behaviourList[i].Setup();
			behaviourList[i].Enter();
		}
	}

	private void LaunchScripts() {
		for(int i = 0; i < scriptList.Count; i++) {
			scriptList[i].Setup();
			scriptList[i].Enter();
		}
	}
}
