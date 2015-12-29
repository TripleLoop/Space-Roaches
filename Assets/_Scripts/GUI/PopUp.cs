using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviourEx
{

    private Animator _popUpAnimator; 

	// Use this for initialization
	void Start ()
	{
	    _popUpAnimator = GetComponent<Animator>();
        _popUpAnimator.SetInteger("Anim", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClosePopUp()
    {
        Messenger.Publish(new StartGameMessage());
        _popUpAnimator.SetInteger("Anim", 2);
    }
}
