using UnityEngine;

public class SceneExitParams
{
   public SceneSwitchInfo switchSceneInfo { get; private set; }

    public SceneEnterParams EnterParams {get; private set; }    

    public SceneExitParams(SceneSwitchInfo switchSceneInfo,SceneEnterParams EnterParams)
    {
        this.switchSceneInfo = switchSceneInfo; 
        this.EnterParams = EnterParams; 
    }

    public SceneExitParams(SceneExitParams sceneExitParams)
    {
        switchSceneInfo = sceneExitParams.switchSceneInfo;
        EnterParams = sceneExitParams.EnterParams;
    }


    public T As<T>() where T : SceneExitParams
    {
        return (T)this;
    }
}
