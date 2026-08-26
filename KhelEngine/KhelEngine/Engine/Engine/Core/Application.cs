using System;
using System.IO;

public static class Application {
	public static string projectPath { get; private set; }

	public static void Initialize() {
		projectPath = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
	}
}