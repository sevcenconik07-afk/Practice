using UnityEngine;

public class SceneEnterParams 
{
    public string SceneName { get; private set; }

    public SceneEnterParams(string sceneName)
    {
        SceneName = sceneName;
    }
    public SceneEnterParams(SceneEnterParams sceneEnterParams)
    {
        SceneName = sceneEnterParams.SceneName;
    }

    public T As<T>() where T : SceneEnterParams
    {
        return (T)this;
    }
}
