# Making a Game
## Initializing 
In your csproj make sure to add:
```csproj
<ItemGroup>
	<Reference Include="KhelEngine">
		<HintPath>[KhelEnigne.dll path]</HintPath>
	</Reference>
	<PackageReference Include="Silk.NET.OpenGL" Version="2.23.0" />
	<PackageReference Include="StbImageSharp" Version="2.30.15" />
</ItemGroup>
```

### Make a scene
To get started make a game scene, make a non static public class inherited form Scene & override the Setup() function
Eg:
```csharp
using KhelEngine.Mathf;

public class MainGameScene : Scene {
    public override void Setup() {
        // Object creation...
    }
}
```

### Make your project settings
Make a project settings file using the IProjectSettings interface.
Eg:
```csharp
using KhelEngine.Mathf;

public class SampleProjectSettings : IProjectSettings {
    public string ProjectName { get; set; } = "Sample";
    public int Width { get; set; } = 1280;
    public int Height { get; set; } = 720;
    public Vector4 bgColor { get; set; } = Color.White;
    public TargetPlatform Platform { get; set; } = TargetPlatform.Windows;
    public List<Scene> workingScenes { get; set; } = [
        new MainGameScene()
    ];
}
```

### Create the game window
Now we will need to write the program file which will execute our game
Eg:
```csharp
public static class Program {
    public static void Main() {
        // Intializes the engine and sets up the project
        Engine.StartGame(new SampleProjectSettings());

        // Loads the first scene into action
        SceneManager.LoadScene(0);

        // Keeps the game running
        while(true) {
            Engine.UpdateGame();
        }
    }
}
```
