using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private Camera _mainCamera;
    private MenuCanvas _menuCanvas;

    private void Start ()
	{
	    this.InitializeCamera()
	        .InitializeBackgorund()
	        .InitializeCanvas()
	        .SetReferences();
	}

    private MainMenu InitializeCamera()
    {
        GameObject mainCamera = SRResources.Menu.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.SetParent(transform);
        _mainCamera = mainCamera.GetComponent<Camera>();
        return this;
    }

    private MainMenu InitializeBackgorund()
    {
        GameObject background = SRResources.Menu.Environment.MainScreenBG.Instantiate();
        background.name = "background";
        background.transform.SetParent(transform);
        return this;
    }

    private MainMenu InitializeCanvas()
    {
        GameObject canvas = SRResources.Menu.UI.Canvas.Instantiate();
        canvas.name = "Canvas";
        canvas.transform.SetParent(this.gameObject.transform, false);
        _menuCanvas = canvas.GetComponent<MenuCanvas>();
        GameObject eventSystem = SRResources.Menu.UI.EventSystem.Instantiate();
        eventSystem.name = "EventSystem";
        eventSystem.transform.SetParent(transform,false);
        return this;
    }

    private MainMenu SetReferences()
    {
        _menuCanvas.Initialize(_mainCamera);
        return this;
    }
}
