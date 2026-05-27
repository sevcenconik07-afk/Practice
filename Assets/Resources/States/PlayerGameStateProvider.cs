using R3;
using UnityEngine;
using System.IO;


public class PlayerGameStateProvider : IGameStateProvider
{
    private readonly string GameStateTag;
    private readonly string GameSettingsStateTag;

    private readonly string GameStatePath;
    private readonly string GameSettingsPath;

    public GameState GameState { get; private set; }
    public GameSettingsState SettingsState { get; private set; }

    private SaveGameState _saveGameStateOrigin;

    private SaveGameSettingsState _saveGameSettingsStateOrigin;

    private SaveAndLoad saveAndLoad = new();

    public PlayerGameStateProvider()
    {
        GameStatePath = Application.persistentDataPath + "/" + GameStateTag;
        GameSettingsPath = Application.persistentDataPath + "/" + GameSettingsStateTag;
    }


    public Observable<GameState> LoadGameState()
    {
        if (File.Exists(GameStatePath))
        {
            _saveGameStateOrigin = saveAndLoad.Load(DeffaltSaveGameStateCreate(), GameStatePath);
            GameState = new GameState(_saveGameStateOrigin);
        }
        else
        {
            GameState = DeffaltGameStateCreate();

            SaveGameState();
        }

       return Observable.Return(GameState);
    }

    public Observable<GameSettingsState> LoadSettingsState()
    {
        if (File.Exists(GameStatePath))
        {
            _saveGameSettingsStateOrigin = saveAndLoad.Load(DeffaltSaveGameSettingsStateCreate(), GameSettingsPath);
            SettingsState = new(_saveGameSettingsStateOrigin);
        }
        else
        {
            SettingsState = DeffaltGameSettingsStateCreate();

            SaveSettingsState();
        }

        return Observable.Return(SettingsState);
    }

    public Observable<bool> ResetGameState()
    {
        GameState = DeffaltGameStateCreate();
        SaveGameState();

        return Observable.Return(true);
    }

    public Observable<GameSettingsState> ResetSettingsState()
    {
        SettingsState = DeffaltGameSettingsStateCreate();
        SaveGameState();

        return Observable.Return(SettingsState);
    }

    public Observable<bool> SaveGameState()
    {
        saveAndLoad.Save(GameState,GameStatePath);

        return Observable.Return(true);
    }

    public Observable<bool> SaveSettingsState()
    {
        saveAndLoad.Save(SettingsState,GameSettingsPath);

        return Observable.Return(true); 
    }

    private GameState DeffaltGameStateCreate()
    {
        return new GameState(DeffaltSaveGameStateCreate());
    }

    private GameSettingsState DeffaltGameSettingsStateCreate()
    {
        return new GameSettingsState(DeffaltSaveGameSettingsStateCreate());
    }
    private SaveGameState DeffaltSaveGameStateCreate()
    {
        return new SaveGameState();
        
    }

    private SaveGameSettingsState DeffaltSaveGameSettingsStateCreate()
    {
        return new SaveGameSettingsState();
    }

}
