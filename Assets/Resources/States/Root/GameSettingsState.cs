using R3;
using UnityEngine;

public class GameSettingsState 
{
    public ReactiveProperty<int> MusicVolume { get; }
    public ReactiveProperty<int> SFXVolume { get; }

    public GameSettingsState(SaveGameSettingsState saveGameSettingsState)
    {
        MusicVolume = new ReactiveProperty<int>(saveGameSettingsState.MusicVolume);
        SFXVolume = new ReactiveProperty<int>(saveGameSettingsState.SFXVolume);

        MusicVolume.Skip(1).Subscribe(value => saveGameSettingsState.MusicVolume = value);
        SFXVolume.Skip(1).Subscribe(value => saveGameSettingsState.SFXVolume = value);
    }
}
