using System;
using System.Collections.Generic;

public static class Input {
	private static HashSet<Key> currentKeys = new HashSet<Key>();
	private static HashSet<Key> previousKeys = new HashSet<Key>();

	public static void Update() {
		previousKeys = new HashSet<Key>(currentKeys);
		currentKeys.Clear();

		foreach(Key key in Enum.GetValues(typeof(Key))) { 
			if(InputBackend.IsKeyPressed(key)) {
				currentKeys.Add(key);
			}
		}
	}

	public static bool GetKey(Key key) { 
		return currentKeys.Contains(key);
	}

	public static bool GetKeyDown(Key key) {
		return currentKeys.Contains(key) && !previousKeys.Contains(key);
	}

	public static bool GetKeyUp(Key key) {
		return !currentKeys.Contains(key) && previousKeys.Contains(key);
	}
}
