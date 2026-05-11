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
