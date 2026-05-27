using UnityEngine;
using R3;

public class UiEntryPoint : MonoBehaviour 
{
    public Observable<UiExitSceneParams> Run(DiContainer UiContainer, UiEnterSceneParams enterParams)
    {
        UiSceneRegistrations.Register(UiContainer, enterParams);
        var UiViewContainer = new DiContainer(UiContainer);
        UiViewRegistrations.Register(UiViewContainer);


        var uiRoot = UiContainer.Resolve<UiRootView>();
        

        var exitSignalSubj = new Subject<UiExitSceneParams>();
        var exitUiSceneSignal = exitSignalSubj.Select(_ => new UiExitSceneParams(_));

        return exitUiSceneSignal;
    }
}
