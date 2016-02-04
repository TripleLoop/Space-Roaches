using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class BasePopupComponent : MonoBehaviour {

    private BasePopUpAnimation _basePopUpAnimation;

    //private Animator _popUpAnimator;
    private Action _onClosePopup;

    public void Initialize(Action onClose)
    {
        //_popUpAnimator = GetComponent<Animator>();
        _basePopUpAnimation = GetComponent<BasePopUpAnimation>();
        _onClosePopup = onClose;
    }

    public void ShowPopUp()
    {
        _basePopUpAnimation.Initialize();
        //_popUpAnimator.SetInteger("Anim", 1);
        _basePopUpAnimation.PlayAnimation(false, OnPopupClosed);
    }

    public void ClosePopUp()
    {
        //_popUpAnimator.SetInteger("Anim", 2);
        _basePopUpAnimation.PlayAnimation();
    }

    public void OnPopupClosed()
    {
        //_popUpAnimator.SetInteger("Anim", 0);
        _onClosePopup();
    }
}
