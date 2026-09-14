using System.Collections.Generic;

public class Scene
{
  public List<Entity> entityList = new List<Entity>();
  private List<Behaviour> entityBehaviourList = new List<Behaviour>();
  private List<Script> entityScriptList = new List<Script>();

  public virtual void Setup() { }

  public virtual void Loop()
  {
    for (int i = 0; i < entityList.Count; i++)
    {
      for (int j = 0; j < entityBehaviourList.Count; j++)
      {
        entityBehaviourList[j].Loop();
      }

      for (int j = 0; j < entityScriptList.Count; j++)
      {
        entityScriptList[j].Loop();
      }
    }
  }

  public virtual void FixedLoop()
  {
    for (int i = 0; i < entityList.Count; i++)
    {
      for (int j = 0; j < entityBehaviourList.Count; j++)
      {
        entityBehaviourList[j].FixedLoop();
      }

      for (int j = 0; j < entityScriptList.Count; j++)
      {
        entityScriptList[j].FixedLoop();
      }
    }
  }

  public void DeleteAllEntities()
  {
    for (int i = 0; i < entityList.Count; i++)
    {
      Deinstantiate.Delete(entityList[i]);
    }
  }

  public virtual void Exit() { }

}
