using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.SceneManagement;
using R3;

public class GameEntryPoint : MonoBehaviour
{
    private static GameEntryPoint _instance;
    private UiRootView _uiRoot;
    private readonly DiContainer _rootContainer = new();
    private DiContainer _cachedSceneContainer;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        _instance = new GameEntryPoint();
        _instance.RunGame();
    }

    private GameEntryPoint()
    {
        var prefabUIRoot = Resources.Load<UiRootView>("UIRoot");
        _uiRoot = Instantiate(prefabUIRoot);
         DontDestroyOnLoad(_uiRoot.gameObject);
        _rootContainer.RegisterInstance(_uiRoot);
                
        var settingsProvider = new SettingsProvider();
        _rootContainer.RegisterInstance<ISettingsProvider>(settingsProvider);

        var gameStateProvider = new PlayerGameStateProvider();
        gameStateProvider.LoadSettingsState();
        _rootContainer.RegisterInstance<IGameStateProvider>(gameStateProvider);
                
    }

    private async void RunGame()
    {
       

#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        SceneSwitchInfo sceneSwitchInfo;
        SceneEnterParams enterParams;

        if (sceneName == ScenesParameters.GameplayScenes.GameplayScene1)
        {
            sceneSwitchInfo = new SceneSwitchInfo(ScenesParameters.SceneType.Gameplay, ScenesParameters.GameplayScenes.GameplayScene1);
            enterParams = new UiEnterSceneParams(ScenesParameters.GameplayScenes.GameplayScene1);

            SceneSwitch(sceneSwitchInfo, enterParams);
            return;
        }

        if (sceneName == ScenesParameters.UiScenes.UiScene1)
        {
             sceneSwitchInfo = new SceneSwitchInfo(ScenesParameters.SceneType.Ui, ScenesParameters.UiScenes.UiScene1);
             enterParams = new UiEnterSceneParams(ScenesParameters.UiScenes.UiScene1);

            SceneSwitch(sceneSwitchInfo, enterParams);
        }

        if (sceneName != ScenesParameters.Stuff.BootScene)
        {
            return;
        }
#endif

        sceneSwitchInfo = new SceneSwitchInfo(ScenesParameters.SceneType.Ui, ScenesParameters.UiScenes.UiScene1);
        enterParams = new UiEnterSceneParams(ScenesParameters.UiScenes.UiScene1);

       SceneSwitch(sceneSwitchInfo,enterParams);
    }

    private void SceneSwitch(SceneSwitchInfo sceneSwitchInfo,SceneEnterParams enterParams)
    {

        switch (sceneSwitchInfo.sceneType)
        {
            case ScenesParameters.SceneType.Gameplay:
              StartCoroutine(LoadAndStartGameplayScene(sceneSwitchInfo.sceneName,enterParams.As<GameplayEntrySceneParams>()));
            break;

            case ScenesParameters.SceneType.Ui:
              StartCoroutine(LoadAndStartUiScene(sceneSwitchInfo.sceneName, enterParams.As<UiEnterSceneParams>()));
            break;

            default:
                StartCoroutine(LoadAndStartUiScene(ScenesParameters.UiScenes.UiScene1));
            break;
            
        }

        
    }
    private void SceneSwitch(SceneExitParams sceneExitParams)
    {
        SceneSwitch(sceneExitParams.switchSceneInfo,sceneExitParams.EnterParams);
    }

    private IEnumerator LoadAndStartGameplayScene(string sceneName,GameplayEntrySceneParams enterParams = null)
    {
        _uiRoot.ShowLoadingScreen();
        _cachedSceneContainer?.Dispose();

        yield return LoadScene(ScenesParameters.Stuff.BootScene);
        yield return LoadScene(sceneName);


        var isGameStateLoaded = false;
        _rootContainer.Resolve<IGameStateProvider>().LoadGameState().Subscribe(_ => isGameStateLoaded = true);
        yield return new WaitUntil(() => isGameStateLoaded);

        var sceneEntryPoint = new GameplayEntryPoint();
        var gameplayContainer = _cachedSceneContainer = new DiContainer(_rootContainer);
        sceneEntryPoint.Run(gameplayContainer, enterParams).Subscribe(gameplayExitParams =>
        {
            SceneSwitch(gameplayExitParams);
        });

        _uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartUiScene(string sceneName,UiEnterSceneParams enterParams = null)
    {
        _uiRoot.ShowLoadingScreen();
        _cachedSceneContainer?.Dispose();

        yield return LoadScene(ScenesParameters.Stuff.BootScene);
        yield return LoadScene(sceneName);

        
        var sceneEntryPoint = new UiEntryPoint();
        var uiContainer = _cachedSceneContainer = new DiContainer(_rootContainer);
        sceneEntryPoint.Run(uiContainer, enterParams).Subscribe(UiExitParams =>
        {

            SceneSwitch(UiExitParams.switchSceneInfo,UiExitParams.EnterParams);
           
        });

        _uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
