using UnityEngine;

public class SceneSwitchInfo : MonoBehaviour
{
    public readonly ScenesParameters.SceneType sceneType;
    public readonly string sceneName;

    public SceneSwitchInfo(ScenesParameters.SceneType sceneType,string sceneName)
    {
        this.sceneType = sceneType;
        this.sceneName = sceneName; 
    }
}
