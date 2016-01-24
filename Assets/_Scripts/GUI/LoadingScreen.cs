using System;
using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    private ChildrenControllerComponent _childrenController;
    private Animator _ownAnimator;
    private Action _loadingDoneCallback;
    private Action _fadeToBlackCallback;

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

    public LoadingScreen ToBlack(Action callback)
    {
        _fadeToBlackCallback = callback;
        _ownAnimator.SetInteger("LoadingState", 3);
        _childrenController.EnableChildren();
        return this;
    }

    public void Blacked()
    {
        _fadeToBlackCallback();
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
