using System;
using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    private ChildrenControllerComponent _childrenController;
    private Animator _ownAnimator;
    private Action _loadingDoneCallback;

    public LoadingScreen Initialize()
    {
        _ownAnimator = GetComponent<Animator>();
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _childrenController.DisableChildren();
        return this;
    }

    public LoadingScreen PreSceneLoading(Action callback)
    {
        _loadingDoneCallback = callback;
        _ownAnimator.SetInteger("LoadingState", 2);
        _childrenController.EnableChildren();
        return this;
    }

    public void LoaderReady()
    {
        _loadingDoneCallback();
    }

    public LoadingScreen Show()
    {
        _ownAnimator.SetInteger("LoadingState", 1);
        _childrenController.EnableChildren();
        return this;
    }

    public LoadingScreen Hide()
    {
        _ownAnimator.SetInteger("LoadingState", 0);
        _childrenController.DisableChildren();
        return this;
    }

    public void Hidden()
    {
       // _childrenController.DisableChildren();
    }
}
