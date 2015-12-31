using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviourEx, IHandle<ShowTutorialMessage>
{

    private Animator _popUpAnimator;

    void Start()
    {
        _popUpAnimator = GetComponent<Animator>();
        Messenger.Publish(new TutorialLoadedMessage());
    }

    public void ClosePopUp()
    {
        Messenger.Publish(new TutorialEndedMessage());
        _popUpAnimator.SetInteger("Anim", 2);
    }

    public void PopupClosed()
    {
        DisableChildren();
    }

    public void Handle(ShowTutorialMessage message)
    {
        EnableChildren();
        _popUpAnimator.SetInteger("Anim", 1);
    }

    private PopUp EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    private PopUp DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }
}
