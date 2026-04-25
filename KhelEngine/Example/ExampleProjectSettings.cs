public class ExampleProjectSettings : IProjectSettings {
	public string ProjectName { get; set; } = "WindowExample";

	public int Width { get; set; } = 1280;
	public int Height { get; set; } = 720;

	public TargetPlatform Platform { get; set; } = TargetPlatform.Windows;
}