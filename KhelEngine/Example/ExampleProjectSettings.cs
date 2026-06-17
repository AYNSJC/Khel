using System.Collections.Generic;

public class ExampleProjectSettings : IProjectSettings {
	public string ProjectName { get; set; } = "ZombieShooterExample";

	public int Width { get; set; } = 1280;
	public int Height { get; set; } = 768;

	public TargetPlatform Platform { get; set; } = TargetPlatform.Windows;

	public List<Scene> workingScenes { get; set; } = new List<Scene>() { 
		new DemoScene()
	};
}