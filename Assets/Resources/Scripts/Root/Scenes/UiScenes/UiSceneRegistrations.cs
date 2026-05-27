using R3;
using UnityEngine;

public static class UiSceneRegistrations 
{
    public static void Register(DiContainer container, UiEnterSceneParams enterParams)
    {
        container.RegisterInstance(AppConstant.EXITSCENEREQUESTTAG, new Subject<UiExitSceneParams>());
        container.RegisterInstance(AppConstant.EXITAPPREQUESTTAG, new Subject<Unit>());
    }
}
