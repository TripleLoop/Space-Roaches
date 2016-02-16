using System;
using UnityEngine;
using System.Collections;

public class TutorialPopUp : MonoBehaviourEx
{
    public TutorialPopUp Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _basePopupComponent = gameObject.GetComponent<BasePopupComponent>();
        _onCloseEndedDelegate = OnCloseEnded;
        _basePopupComponent.Initialize(_onCloseEndedDelegate);
        return this;
    }

    public IEnumerator OpenPopUp()
    {
        _childrenController.EnableChildren();
        _basePopupComponent.ShowPopUp();
        _popupClosed = false;
        while (!_popupClosed)
        {
            yield return null;
        }
    }

    public void ClosePopUp()
    {
        if (_popupClosed) return;
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        _basePopupComponent.ClosePopUp();
        _popupClosed = true;
    }

    public void OnCloseEnded()
    {
        _childrenController.DisableChildren();
    }

    private bool _popupClosed;
    private ChildrenControllerComponent _childrenController;
    private BasePopupComponent _basePopupComponent;
    private Action _onCloseEndedDelegate;
}
