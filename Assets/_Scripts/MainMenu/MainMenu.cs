using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private Camera _mainCamera;

    private void Start ()
	{
	    this.InitializeCamera()
	        .InitializeBackgorund()
	        .InitializeCanvas()
	        .SetReferences();
	}

    private MainMenu InitializeCamera()
    {
        GameObject mainCamera = SRResources.Menu.Base.BaseCamera.Instantiate(); ;
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        _mainCamera = mainCamera.GetComponent<Camera>();
        return this;
    }

    private MainMenu InitializeBackgorund()
    {
        return this;
    }

    private MainMenu InitializeCanvas()
    {
        return this;
    }

    private MainMenu SetReferences()
    {
        return this;
    }
}
