using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    private ChildrenControllerComponent _childrenController;

    public LoadingScreen Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _childrenController.DisableChildren();
        return this;
    }

    public LoadingScreen Enable()
    {
        _childrenController.EnableChildren();
        return this;
    }

    public LoadingScreen Disable()
    {
        _childrenController.DisableChildren();
        return this;
    }
}
