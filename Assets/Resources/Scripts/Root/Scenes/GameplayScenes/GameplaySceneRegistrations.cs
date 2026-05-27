using R3;
using UnityEngine;

public static class GameplaySceneRegistrations 
{
    public static void Register(DiContainer container, GameplayEntrySceneParams gameplayEnterParams)
    {
        var gameStateProvider = container.Resolve<IGameStateProvider>();
        var gameState = gameStateProvider.GameState;
        var settingsProvider = container.Resolve<ISettingsProvider>();


        container.RegisterInstance(AppConstant.EXITSCENEREQUESTTAG, new Subject<GameplayExitSceneParams>());
        container.RegisterInstance(AppConstant.EXITAPPREQUESTTAG, new Subject<Unit>());

    }
}
