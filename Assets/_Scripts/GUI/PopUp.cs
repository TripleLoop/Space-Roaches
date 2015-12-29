using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviourEx {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClosePopUp()
    {
        Messenger.Publish(new StartGameMessage());
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
