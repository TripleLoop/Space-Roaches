using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private ChildrenControllerComponent _childrenController;
    private Animator _ownAnimator;

    private bool loadingReady = false;
  
    private Action _fadeToBlackCallback;

    public LoadingScreen Initialize()
    {
        _ownAnimator = GetComponent<Animator>();
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _childrenController.DisableChildren();
        return this;
    }

    public IEnumerator PreSceneLoading()
    {
        _ownAnimator.SetInteger("LoadingState", 2);
        _childrenController.EnableChildren();
        loadingReady = false;
        while (!loadingReady)
        {
            yield return null;
        }
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
        loadingReady = true;
    }

    public LoadingScreen Show()
    {
        _ownAnimator.SetInteger("LoadingState", 1);
        _childrenController.EnableChildren();
        return this;
    }

    public LoadingScreen Hide(bool forced)
    {
        _ownAnimator.SetInteger("LoadingState", 0);
        if (forced)
        {
            _childrenController.DisableChildren();
        }
        return this;
    }

    public void Hidden()
    {
        _childrenController.DisableChildren();
    }
}
