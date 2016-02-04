using UnityEngine;
using System.Collections;

public class TutorialPopUp : MonoBehaviourEx
{
    public TutorialPopUp Initialize()
    {
        _popUpAnimator = GetComponent<Animator>();
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        return this;
    }

    public void ClosePopUp()
    {
        if (_popupClosed) return;
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        _popUpAnimator.SetInteger("Anim", 2);
        _popupClosed = true;
    }

    public void PopupClosed()
    {
        _childrenController.DisableChildren();
    }

    public IEnumerator OpenPopUp()
    {
        _childrenController.EnableChildren();
        _popUpAnimator.SetInteger("Anim", 1);
        _popupClosed = false;
        while (!_popupClosed)
        {
            yield return null;
        }
    }

    private bool _popupClosed;
    private Animator _popUpAnimator;
    private ChildrenControllerComponent _childrenController;
}
