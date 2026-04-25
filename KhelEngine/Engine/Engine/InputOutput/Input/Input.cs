using System;
using System.Collections.Generic;

public static class Input {
	private static HashSet<WindowsKeyCode> currentKeys = new HashSet<WindowsKeyCode>();
	private static HashSet<WindowsKeyCode> previousKeys = new HashSet<WindowsKeyCode>();

	public static void Update() {
		previousKeys = new HashSet<WindowsKeyCode>(currentKeys);
		currentKeys.Clear();

		foreach(WindowsKeyCode key in Enum.GetValues(typeof(WindowsKeyCode))) { 
			if(InputBackend.IsKeyPressed(key)) {
				currentKeys.Add(key);
			}
		}
	}

	public static bool GetKey(WindowsKeyCode key) { 
		return currentKeys.Contains(key);
	}

	public static bool GetKeyDown(WindowsKeyCode key) {
		return currentKeys.Contains(key) && !previousKeys.Contains(key);
	}

	public static bool GetKeyUp(WindowsKeyCode key) {
		return !currentKeys.Contains(key) && previousKeys.Contains(key);
	}
}
