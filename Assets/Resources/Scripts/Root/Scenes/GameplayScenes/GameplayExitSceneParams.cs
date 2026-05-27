using UnityEngine;

public class GameplayExitSceneParams : SceneExitParams
{
    public GameplayExitSceneParams(SceneSwitchInfo sceneSwitchInfo, SceneEnterParams EnterParams) : base(sceneSwitchInfo, EnterParams)
    {

    }

    public GameplayExitSceneParams(SceneExitParams sceneExitParams) : base(sceneExitParams)
    {

    }
}
