using System;
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviourEx, IHandle<PublishScoreMessage>
{

    private Camera _mainCamera;
    private MenuCanvas _menuCanvas;

    private SoundManager _soundManager;
    private BackendProxy _backendProxy;
    private PlayerPrefsManager _playerPrefsManager;

    private void Start()
    {
        this.InitializeBackend()
            .InitializePlayerPrefsManager()
            .InitializeSoundManager()
            .InitializeBackgorund()
            .InitializeCanvas()
            .InitializeCamera()
            .SetReferences()
            .Launch();
    }


    public void Handle(PublishScoreMessage message)
    {
        if (!ConnectionError())
        {
            StartCoroutine(PublishScoreProcess());
        }
        return;
    }

    private IEnumerator LoginUser()
    {
        _menuCanvas.EnableLoading();
        yield return _backendProxy.LogUser();
        _menuCanvas.DisableLoading();
        ConnectionError();
        _menuCanvas.EnableButtons();
        yield break;
    }

    private IEnumerator PublishScoreProcess()
    {
        _menuCanvas.EnableLoading();
        if (!_playerPrefsManager.ScorePublished)
        {
            int score = _playerPrefsManager.GetScore();
            yield return _backendProxy.PublishScore(score);
        }
        yield return _backendProxy.ShowLeaderboard();
        _menuCanvas.DisableLoading();
    }

    private bool ConnectionError()
    {
        if (!_backendProxy.AuthenticationDone() && !_backendProxy.UserAuthenticated())
        {
            Messenger.Publish(new ShowAlertMessage("Connection failed try again later \n to be able to use the online features"));
            return false;
        }
        if (_backendProxy.AuthenticationDone() && !_backendProxy.UserAuthenticated())
        {
            Messenger.Publish(new ShowAlertMessage("Without authentication you are not going \n to be able to use the online features"));
            return false;
        }
        return true;
    }

    private MainMenu Launch()
    {
        AudioSetUp();
        StartCoroutine(LoginUser());
        return this;
    }

    private MainMenu AudioSetUp()
    {
        _soundManager.SetAudioState();
        Messenger.Publish(new PlayMusicMessage(SRResources.Core.Audio.Clips.Music.RoachMenu));
        return this;
    }

    private MainMenu SetReferences()
    {
        _menuCanvas.Initialize(_mainCamera);
        return this;
    }

    private MainMenu InitializeBackend()
    {
        GameObject backendProxy = SRResources.Core.Base.BackendProxy.Instantiate();
        backendProxy.name = "backendProxy";
        backendProxy.transform.SetParent(transform);
        _backendProxy = backendProxy.GetComponent<BackendProxy>();
        _backendProxy.Initialize();
        return this;
    }

    private MainMenu InitializePlayerPrefsManager()
    {
        GameObject playerPrefsManager = SRResources.Core.Base.PlayerPrefsManager.Instantiate();
        playerPrefsManager.name = "playerPrefsManager";
        playerPrefsManager.transform.SetParent(transform);
        _playerPrefsManager = playerPrefsManager.GetComponent<PlayerPrefsManager>();
        _playerPrefsManager.Initialize();
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
        background.transform.position = new Vector3(0, 0, -3.5f);
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
        eventSystem.transform.SetParent(transform, false);
        _menuCanvas.DisableButtons();
        return this;
    }


}
