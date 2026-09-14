using System.Diagnostics;

public static class Engine
{
  private static Stopwatch stopwatch = Stopwatch.StartNew();
  private static long lastElapsedTime = stopwatch.ElapsedMilliseconds;

  private static float fixedTimer = 0f;
  private const float fixedStep = 0.016f;

  public static float timeScale { get; set; } = 1f;

  public static float deltaTime { get; private set; }

  public static OutputWindow window;

  public static OutputWindow Windom => window;

  private static IProjectSettings projectSettings;

  public static IProjectSettings ProjectSettings => projectSettings;

  public static void StartGame(IProjectSettings pS)
  {
    projectSettings = pS;

    if (pS.Height == 0 || pS.Width == 0)
    {
      Logger.Error("Window dimensions can't be 0");

      return;
    }

    window = new OutputWindow(pS.Width, pS.Height, pS.ProjectName, pS.bgColor);

    Application.Initialize();

    SceneManager.UpdateSceneList(pS.workingScenes);
  }

  public static void UpdateGame()
  {
    CalculateDeltaTime();

    window.PollEvents();
    window.Render();
    EngineGameLoopManager.UpdateGame();
    RunFixedLoop();
  }

  private static void CalculateDeltaTime()
  {
    long currentTime = stopwatch.ElapsedMilliseconds;
    float realTimeElapsed = (currentTime - lastElapsedTime) / 1000f;
    lastElapsedTime = currentTime;

    deltaTime = realTimeElapsed * timeScale;

    fixedTimer += deltaTime;
  }

  private static void RunFixedLoop()
  {
    long currentTime = stopwatch.ElapsedMilliseconds;
    float realTimeElapsed = (currentTime - lastElapsedTime) / 1000f;
    lastElapsedTime = currentTime;

    deltaTime = realTimeElapsed * timeScale;

    fixedTimer += deltaTime;

    while (fixedTimer >= fixedStep)
    {
      EngineGameFixedLoopManager.UpdateGame();
      fixedTimer -= fixedStep;
    }
  }
}
