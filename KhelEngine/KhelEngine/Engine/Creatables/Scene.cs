using System.Collections.Generic;

public class Scene {
	public bool isActive;

	public List<Entity> entities = new List<Entity>();

	public virtual void Setup() { }
}
