using System;
using System.Collections.Generic;

public static class Input {
	private static HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();
	private static HashSet<ConsoleKey> previousKeys = new HashSet<ConsoleKey>();

	public static void Update() {
		previousKeys = new HashSet<ConsoleKey>(currentKeys);
		currentKeys.Clear();

		while(Console.KeyAvailable) {
			var key = Console.ReadKey(true).Key;
			currentKeys.Add(key);
		}
	}

	public static bool GetKey(ConsoleKey key) { 
		return currentKeys.Contains(key);
	}

	public static bool GetKeyDown(ConsoleKey key) {
		return currentKeys.Contains(key) && !previousKeys.Contains(key);
	}

	public static bool GetKeyUp(ConsoleKey key) {
		return !currentKeys.Contains(key) && previousKeys.Contains(key);
	}
}
