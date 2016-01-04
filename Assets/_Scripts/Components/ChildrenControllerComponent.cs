using UnityEngine;

public class ChildrenControllerComponent : MonoBehaviour {


    public ChildrenControllerComponent EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    public ChildrenControllerComponent DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }

}
