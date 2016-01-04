using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertPopUp : MonoBehaviourEx, IHandle<ShowAlertMessage>
{
    private ChildrenControllerComponent _childrenController;

    private Text _messageText;

    public AlertPopUp Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _messageText = GetComponentsInChildren<Text>(true)[0];
        return this;
    }

    public void Handle(ShowAlertMessage message)
    {
        _childrenController.EnableChildren();
        _messageText.text = message.Message;
        return;
    }

    public void ClosePopUp()
    {
        _childrenController.DisableChildren();
        return;
    }
}
