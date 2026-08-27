using System.Collections.Generic;

public class Scene {
	public List<Entity> entityList = new List<Entity>();

	public virtual void Setup() { }

	public virtual void Loop() {
		for(int i = 0; i < entityList.Count; i++) {
			List<Behaviour> behaviourScriptList = entityList[i].behaviourList;
			List<Script> entityScriptList = entityList[i].scriptList;

			for(int j = 0; j < behaviourScriptList.Count; j++) {
				behaviourScriptList[j].Loop();
			}

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].Loop();
			}
		}
	}

	public virtual void FixedLoop() {
		for(int i = 0; i < entityList.Count; i++) {
			List<Behaviour> entitybehaviourList = entityList[i].behaviourList;

			for(int j = 0; j < entitybehaviourList.Count; j++) {
				entitybehaviourList[j].FixedLoop();
			}

			List<Script> entityScriptList = entityList[i].scriptList;

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].FixedLoop();
			}
		}
	}
	
	public void DeleteAllEntities() {
		for(int i = 0; i < entityList.Count; i++) {
			Deinstantiate.Delete(entityList[i]);
		}
	}

	public virtual void Exit() { }

}
