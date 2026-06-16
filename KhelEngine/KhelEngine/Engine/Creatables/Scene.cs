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
			List<Script> entityScriptList = entityList[i].scriptList;

			for(int j = 0; j < entityScriptList.Count; j++) {
				entityScriptList[j].FixedLoop();
			}
		}
	}

	public virtual void Exit() { }
}
