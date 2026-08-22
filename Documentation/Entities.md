\# Entities

All entities have the transform behaviour attached to them. This gives the entities their position, rotation \& scale. All the behaviours and scripts are attached to entities.



\## Manipulating an Entity

To create an entity you will need to create a non static class inheriting the Entity class. All the behaviours and scripts that need to be attached to the object initially can be attached in the constructor.

Eg:

```csharp

public class Player : Entity {

    public Player() {

        AddBehaviour(Behaviour);

        AddScript(Script);
    }

}

```



These entities can be dynamically created to deleted at runtime, but at-least 1 entity is need in the scene for any script to run. To create or delete an object use the commands given below:

```csharp

// Creating the Entity

Instantiate.Create(new Entity(), Vector2.Zero, 0f, Vector2.One);



// Deleting the Entity

Deinstantiate.Delete(entity);

```



\## Accessing an Entity

To access the Entity, or get it's behaviours and scripts, we can use the GetBehaviour() or GetScript() functions on the entity

Eg:

```csharp

entity.GetBehaviour(Behaviour);

entity.GetScript(Script);



ImageRenderer imgRen = (ImageRenderer)entity.GetBehaviour(ImageRenderer);

```



\## Parenting

Entities can have parents which effect their transform in world position. To change an entities position irrespective of it it's parent use localPosition, localRotation \& localScale.

To assign a parent use:

```csharp

entity.transform.SetParent(parent)

```



