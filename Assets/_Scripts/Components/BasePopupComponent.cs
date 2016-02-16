using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class BasePopupComponent : MonoBehaviour {
    
    public void Initialize(Action onClose)
    {
        _popUpAnimator = GetComponent<Animator>();
        _onClosePopup = onClose;
    }

    public void ShowPopUp()
    {
        _popUpAnimator.SetInteger("Anim", 1);
    }

    public void ClosePopUp()
    {
        _popUpAnimator.SetInteger("Anim", 2);
    }

    public void OnPopupClosed()
    {
        _popUpAnimator.SetInteger("Anim", 0);
        _onClosePopup();
    }

    private Animator _popUpAnimator;
    private Action _onClosePopup;
}
