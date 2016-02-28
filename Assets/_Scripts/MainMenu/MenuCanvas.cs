using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviourEx
{
    //Menu Buttons
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _leaderboardButton;
    [SerializeField]
    private Button _configurationButton;

    //SubMenu Classes
    private SettingsMenu _settingsMenu;
    //private LeaderboardMenu _leaderboardMenu;

    public delegate MenuCanvas EnableDelegate();
    private EnableDelegate _enableDelegate;

    //Helpers
    private AlertPopUp _alertPopUp;
    private LoadingScreen _loadingScreen;

    public MenuCanvas Initialize(Camera mainCamera, bool tutorialForced)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        _settingsMenu = GetComponentInChildren<SettingsMenu>();
        _settingsMenu.Initialize(tutorialForced);
        //_leaderboardMenu = GetComponentInChildren<LeaderboardMenu>();
        _enableDelegate = EnableButtons;
        InitializeAlertPopUp()
            .InitializeLoadingScreen();
        return this;
    }

    /// <summary>
    /// Function executed by pressing the _play button
    /// </summary>
    public void Play()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.Confirm));
        PlayerPrefs.Save();
        DisableButtons();
        Action callback = StartSceneChange;
        _loadingScreen.ToBlack(callback);
    }

    private void StartSceneChange()
    {
        SceneManager.LoadScene(SRScenes.MainGame);
    }
    /// <summary>
    /// Function executed by pressing the _leaderboardButton button
    /// </summary>
    public void Leaderboard()
    {
        //DisableButtons();
        //DisableButtons();
        //_leaderboardMenu.Show(_enableDelegate);
        //Debug.Log("opened _leaderboardButton");
        Messenger.Publish(new PublishScoreMessage());
    }

    /// <summary>
    /// Function executed by pressing the _configurationButton button
    /// </summary>
    public void Configuration()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        DisableButtons();
        _settingsMenu.Show(_enableDelegate);
        //Debug.Log("opened _configurationButton");
    }

    public MenuCanvas EnableButtons()
    {
        _playButton.interactable = true;
        _leaderboardButton.interactable = true;
        _configurationButton.interactable = true;
        return this;
    }

    public MenuCanvas DisableButtons()
    {
        _playButton.interactable = false;
        _leaderboardButton.interactable = false;
        _configurationButton.interactable = false;
        return this;
    }

    public MenuCanvas EnableLoading()
    {
        _loadingScreen.Show();
        return this;
    }

    public MenuCanvas DisableLoading(bool forced)
    {
        _loadingScreen.Hide(forced);
        return this;
    }

    private MenuCanvas InitializeAlertPopUp()
    {
        GameObject alertPopUp = SRResources.Core.UI.AlertPopUp.Instantiate();
        alertPopUp.transform.SetParent(gameObject.transform, false);
        _alertPopUp = alertPopUp.GetComponent<AlertPopUp>();
        _alertPopUp.Initialize();
        return this;
    }

    private MenuCanvas InitializeLoadingScreen()
    {
        GameObject loadingScreen = SRResources.Core.UI.LoadingScreen.Instantiate();
        loadingScreen.transform.SetParent(gameObject.transform, false);
        _loadingScreen = loadingScreen.GetComponent<LoadingScreen>();
        _loadingScreen.Initialize();
        return this;
    }
}
