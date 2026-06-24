using KhelEngine.Mathf;
using System.Collections.Generic;

public class ExampleProjectSettings : IProjectSettings {
	public string ProjectName { get; set; } = "Zombie Shooter Example";

	public int Width { get; set; } = 1280;
	public int Height { get; set; } = 768;

	public TargetPlatform Platform { get; set; } = TargetPlatform.Windows;

	public Vector4 bgColor { get; set; } = new Vector4(0f, 0f, 0f, 1f);

	public List<Scene> workingScenes { get; set; } = new List<Scene>() { 
		new DemoScene()
	};
}