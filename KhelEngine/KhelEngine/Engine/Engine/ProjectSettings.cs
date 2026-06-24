using System.Collections.Generic;
using KhelEngine.Mathf;

public interface IProjectSettings {
	string ProjectName { get; set; }

	int Width { get; set; }
	int Height { get; set; }

	Vector4 bgColor { get; set; }

	TargetPlatform Platform { get; set; }

	List<Scene> workingScenes { get; set; }
}

public enum TargetPlatform {
	Windows,
	Linux
}