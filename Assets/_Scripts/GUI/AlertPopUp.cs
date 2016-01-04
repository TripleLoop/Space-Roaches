using UnityEngine;
using System.Collections;

public class AlertPopUp : MonoBehaviour
{
    private ChildrenControllerComponent _childrenController;

    public AlertPopUp Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        return this;
    }

}
