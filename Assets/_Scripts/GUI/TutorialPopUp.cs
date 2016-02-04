using UnityEngine;
using System.Collections;

public class TutorialPopUp : MonoBehaviourEx
{
    public TutorialPopUp Initialize()
    {
        //_popUpAnimator = GetComponent<Animator>();
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _basePopUpAnimation = GetComponent<BasePopUpAnimation>();
        _basePopUpAnimation.Initialize();
        return this;
    }

    public void ClosePopUp()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        Messenger.Publish(new TutorialEndedMessage());
        //_popUpAnimator.SetInteger("Anim", 2);
        _basePopUpAnimation.PlayAnimation();
    }

    public void PopupClosed()
    {
        _childrenController.DisableChildren();
    }

    public TutorialPopUp OpenPopUp()
    {
        _childrenController.EnableChildren();
        //_popUpAnimator.SetInteger("Anim", 1);
        _basePopUpAnimation.PlayAnimation(false, PopupClosed);
        return this;
    }

    //private Animator _popUpAnimator;
    private ChildrenControllerComponent _childrenController;
    private BasePopUpAnimation _basePopUpAnimation;
}
