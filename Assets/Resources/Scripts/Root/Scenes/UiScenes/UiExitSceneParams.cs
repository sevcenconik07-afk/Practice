using UnityEngine;

public class UiExitSceneParams : SceneExitParams
{
  
    public UiExitSceneParams(SceneSwitchInfo sceneSwitchInfo, SceneEnterParams EnterParams): base(sceneSwitchInfo, EnterParams) 
    {
            
    }

    public UiExitSceneParams(SceneExitParams sceneExitParams) : base(sceneExitParams)
    {

    }
}
