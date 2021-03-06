﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviourEx, IHandle<PublishScoreMessage>
{
    
    private void Start()
    {
        this.InitializeBackend()
            .InitializePlayerPrefsManager()
            .InitializeSoundManager()
            .InitializeEnvironment()
            .InitializeCanvas()
            .InitializeCamera()
            .SetReferences()
            .Launch();
    }

    public void Handle(PublishScoreMessage message)
    {
        if (!_playerPrefsManager.UserAuthenticated)
        {
            Messenger.Publish(new ShowAlertMessage("Without authentication you can't \n access the leaderboard"));
            return;
        }
        if (!_playerPrefsManager.ScorePublished)
        {
            _menuCanvas.DisableLoading(true);
            _menuCanvas.DisableButtons();
            int score = _playerPrefsManager.GetScore();
            _backendProxy.PublishScore(score, _postingDelegate);
            return;
        }
        _backendProxy.ShowLeaderboard();
        return;
    }

    private void LoginFinished(bool suceess)
    {
        if (!suceess)
        {
            Messenger.Publish(new ShowAlertMessage("Without authentication you are not going \n to be able to use the online features"));
        }
        else
        {
            _playerPrefsManager.UserAuthenticated = true;
        }
        _menuCanvas.DisableLoading(true);
        _menuCanvas.EnableButtons();
    }

    private void PostingFinished(bool suceess)
    {
        if (!suceess)
        {
            Messenger.Publish(new ShowAlertMessage("Score Posting failed \n try again later"));
        }
        _menuCanvas.DisableLoading(true);
        _menuCanvas.EnableButtons();
        _backendProxy.ShowLeaderboard();
    }

    private MainMenu Launch()
    {
        AudioSetUp();
        _menuCanvas.EnableLoading();
        _menuCanvas.DisableButtons();
        _backendProxy.LogUser(_loginDelegate);
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
        _menuCanvas.Initialize(_mainCamera, _playerPrefsManager, _playerPrefsManager.TutorialForced);
        _loginDelegate = LoginFinished;
        _postingDelegate = PostingFinished;
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

    private MainMenu InitializeCanvas()
    {
        GameObject canvas = SRResources.Menu.UI.Canvas.Instantiate();
        canvas.name = "Canvas";
        canvas.transform.SetParent(this.gameObject.transform, false);
        _menuCanvas = canvas.GetComponent<MenuCanvas>();
        if (EventSystem.current == null)
        {
            GameObject eventSystem = SRResources.Menu.UI.EventSystem.Instantiate();
            eventSystem.name = "EventSystemIn";
            eventSystem.transform.SetParent(transform, false);
        }
        if (Debug.isDebugBuild)
        {
            SRDebug.Init();
        }
        _menuCanvas.DisableButtons();
        return this;
    }

    private MainMenu InitializeEnvironment()
    {
        GameObject environment = SRResources.Menu.Environment.MenuEnvironment.Instantiate();
        environment.name = "Environment";
        environment.transform.SetParent(transform);
        environment.GetComponent<MainScreenEnvironment>().Initialize();
        return this;
    }

    private Camera _mainCamera;
    private MenuCanvas _menuCanvas;

    private SoundManager _soundManager;
    private BackendProxy _backendProxy;
    private PlayerPrefsManager _playerPrefsManager;

    private Action<bool> _loginDelegate;
    private Action<bool> _postingDelegate;


}
