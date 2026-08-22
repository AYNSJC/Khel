using System;
using System.Collections.Generic;
using KhelEngine.Mathf;

public static class Input {
    private static HashSet<KeyCode> currentKeys = new HashSet<KeyCode>();
    private static HashSet<KeyCode> previousKeys = new HashSet<KeyCode>();

    public static void Update() {
        previousKeys = new HashSet<KeyCode>(currentKeys);
        currentKeys.Clear();

        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode))) {
            if(InputBackend.IsKeyPressed(key)) {
                currentKeys.Add(key);
            }
        }
    }

    public static Vector2 GetMousePosition() {
        return InputBackend.GetMousePosition();
    }

    public static Vector2 GetMouseWorldPosition() {
        int windowWidth = Engine.ProjectSettings.Width;
        int windowHeight = Engine.ProjectSettings.Height;

        Vector2 mouse = GetMousePosition();

        float ndcX = (mouse.x / windowWidth) * 2f - 1f;
        float ndcY = 1f - (mouse.y / windowHeight) * 2f;

        float aspect = (float)windowWidth / windowHeight;

        float worldHeight = 10f;
        float worldWidth = worldHeight * aspect;

        return new Vector2(
            ndcX * (worldWidth / 2f),
            ndcY * (worldHeight / 2f)
        );
    }

    public static bool GetKey(KeyCode key) {
        return currentKeys.Contains(key);
    }

    public static bool GetKeyDown(KeyCode key) {
        return currentKeys.Contains(key) && !previousKeys.Contains(key);
    }

    public static bool GetKeyUp(KeyCode key) {
        return !currentKeys.Contains(key) && previousKeys.Contains(key);
    }

    public static bool MouseClick(int mouseClick, Entity entity) {
        if(mouseClick == 0 && GetKey(KeyCode.LEFT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 1 && GetKey(KeyCode.RIGHT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 2 && GetKey(KeyCode.MIDDLE_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else {
            return false;
        }
    }

    public static bool MouseClickDown(int mouseClick, Entity entity) {
        if(mouseClick == 0 && GetKeyDown(KeyCode.LEFT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 1 && GetKeyDown(KeyCode.RIGHT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 2 && GetKeyDown(KeyCode.MIDDLE_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else {
            return false;
        }
    }

    public static bool MouseClickUp(int mouseClick, Entity entity) {
        if(mouseClick == 0 && GetKeyUp(KeyCode.LEFT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 1 && GetKeyUp(KeyCode.RIGHT_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else if(mouseClick == 2 && GetKeyUp(KeyCode.MIDDLE_MOUSE_BUTTON)) {
            return MouseOverlapsCollider(entity);
        }
        else {
            return false;
        }
    }

    public static bool MouseOverlap(Entity entity) {
        return MouseOverlapsCollider(entity);
    }

    private static bool MouseOverlapsCollider(Entity entity) {
        if(entity.GetBehaviour<CircleCollider>() != null) {
            if(Vector2.Distance(entity.transform.position, GetMouseWorldPosition()) <= entity.GetBehaviour<CircleCollider>().radius) {
                return true;
            }
            else {
                return false;
            }
        }
		if(entity.GetBehaviour<BoxCollider>() != null) {
            BoxCollider box = entity.GetBehaviour<BoxCollider>();
			if(GetMouseWorldPosition().x < box.position().x + box.size.x && GetMouseWorldPosition().x > box.position().x - box.size.x &&
				GetMouseWorldPosition().y < box.position().y + box.size.y && GetMouseWorldPosition().y > box.position().y - box.size.y) {
				return true;
			}
			else {
				return false;
			}
		}
		else {
            return false;
        }
    }
}
