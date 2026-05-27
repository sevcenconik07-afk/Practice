using UnityEngine;

public static class ScenesParameters
{
    public class GameplayScenes 
    {
        public const string GameplayScene1 = "Level1";
    }

    public class UiScenes
    {
        public const string UiScene1 = "MainMenu";
    }
    
    public class Stuff
    {
        public const string BootScene = "Boot";
    }

    public enum SceneType
    {
        Gameplay,
        Ui
    }
}
