using R3;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class GameplayEntryPoint : MonoBehaviour
{
    public Observable<GameplayExitSceneParams> Run(DiContainer gameplayContainer, GameplayEntrySceneParams enterParams)
    {

        GameplaySceneRegistrations.Register(gameplayContainer, enterParams);
        var gameplayViewContainer = new DiContainer(gameplayContainer);
        GameplayViewRegistrations.Register(gameplayViewContainer);

        InitWorld(gameplayViewContainer);
        InitUI(gameplayViewContainer);

        var exitSceneRequest = gameplayContainer.Resolve<Subject<SceneExitParams>>(AppConstant.EXITSCENEREQUESTTAG);
        var exitGameplaySceneSignal = exitSceneRequest.Select(_ => new GameplayExitSceneParams(_));
        return exitGameplaySceneSignal;
    }
    private void DeffaultLoad()
    {

    }
    private void InitWorld(DiContainer viewsContainer)
    {
       
    }

    private void InitUI(DiContainer viewsContainer)
    {

    }
}
