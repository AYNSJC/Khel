public interface IProjectSettings {
	string ProjectName { get; set; }

	int Width { get; set; }
	int Height { get; set; }

	TargetPlatform Platform { get; set; }
}

public enum TargetPlatform {
	Windows,
	Linux
}