using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviourEx {

    private Camera _mainCamera;
    private MenuCanvas _menuCanvas;

    private SoundManager _soundManager;

    private void Start ()
    {
        this.Initialize()
            .InitializeCamera()
            .InitializePlayerPrefsManager()
            .InitializeSoundManager()
            .InitializeBackgorund()
            .InitializeCanvas()
            .SetReferences()
            .AudioSetUp();
    }

    private MainMenu AudioSetUp()
    {
        _soundManager.SetAudioState();
        Messenger.Publish(new PlayMusicMessage(SRResources.Core.Audio.Clips.Music.RoachMenu));
        return this;
    }

    private MainMenu Initialize()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
        return this;
    }

    private MainMenu InitializePlayerPrefsManager()
    {
        GameObject playerPrefsManager = SRResources.Core.Base.PlayerPrefsManager.Instantiate();
        playerPrefsManager.name = "playerPrefsManager";
        playerPrefsManager.transform.SetParent(transform);
        return this;
    }

    private MainMenu InitializeCamera()
    {
        GameObject mainCamera = SRResources.Core.Base.BaseCamera.Instantiate();
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

    private MainMenu InitializeSoundManager()
    {
        GameObject waveManager = SRResources.Core.Base.SoundManager.Instantiate();
        waveManager.name = "SoundManager";
        waveManager.transform.SetParent(this.gameObject.transform, false);
        _soundManager = waveManager.GetComponent<SoundManager>().InitializeSources();
        return this;
    }

}
