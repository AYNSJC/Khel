using KhelEngine.Mathf;
using System.Collections.Generic;

public class Entity {
	public Entity Parent;
	public List<Entity> Children;

	public Transform transform = new Transform();
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

	public static T FindFirstEntityOfType<T>() where T : Entity {
		List<Entity> allEntites = SceneManager.activeScene.entityList;

		for(int i = 0;i < allEntites.Count; i++) {
			if(allEntites[i] is T entity) {
				return entity;
			}
		}

		return null;
	}

	public static List<Entity> FindEntitiesOfType<T>() where T : Entity {
		List<Entity> allEntites = SceneManager.activeScene.entityList;

		List<Entity> entityToReturn = new List<Entity>();

		for(int i = 0; i < allEntites.Count; i++) {
			if(allEntites[i] is T entity) {
				entityToReturn.Add(entity);
			}
		}

		return entityToReturn;
	}

	public Entity AddChild(Entity cEntity, Vector2 cPosition, float cRotation, Vector2 cScale) {
		return Instantiate.Create(cEntity, cPosition, cRotation, cScale);
	}

	public void Setup() {
		AddBehaviour(transform);
		transform.entity = this;

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
