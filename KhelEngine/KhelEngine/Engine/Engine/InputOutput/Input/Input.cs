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
}
