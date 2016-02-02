using System;
using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    ///TODO: Instantiate all the canvas components to ensure they are loaded
    public CanvasManager Initialize(SpaceRoaches spaceRoaches, Camera gameCamera)
    {
        GetComponent<Canvas>().worldCamera = gameCamera;
        _roachCount = GetComponentInChildren<RoachCount>();
        _dashMeter = GetComponentInChildren<DashMeter>();
        _endScreen = GetComponentInChildren<EndScreen>();
        _endScreen.Initialize(_roachCount, spaceRoaches);
        InitializeAlertPopUp()
            .InitializeLoadingScreen()
            .InitializeTutorialPopUp();
        return this;
    }

    public CanvasManager Reset()
    {
        _roachCount.Reset();
        _dashMeter.Reset();
        _endScreen.Reset();
        return this;
    }

    public CanvasManager LoadingToBlack(Action callback)
    {
        _loadingScreen.ToBlack(callback);
        return this;
    }

    public CanvasManager ShowLoading(Action callback)
    {
        _loadingScreen.PreSceneLoading(callback);
        return this;
    }

    public CanvasManager HideLoading(bool forced)
    {
        _loadingScreen.Hide(forced);
        return this;
    }

    public CanvasManager ShowTutorial()
    {
        _tutorialPopUp.OpenPopUp();
        return this;
    }

    private CanvasManager InitializeAlertPopUp()
    {
        GameObject alertPopUp = SRResources.Core.UI.AlertPopUp.Instantiate();
        alertPopUp.transform.SetParent(gameObject.transform, false);
        _alertPopUp = alertPopUp.GetComponent<AlertPopUp>();
        _alertPopUp.Initialize();
        return this;
    }

    private CanvasManager InitializeLoadingScreen()
    {
        GameObject loadingScreen = SRResources.Core.UI.LoadingScreen.Instantiate();
        loadingScreen.transform.SetParent(gameObject.transform, false);
        _loadingScreen = loadingScreen.GetComponent<LoadingScreen>();
        _loadingScreen.Initialize();
        return this;
    }

    private CanvasManager InitializeTutorialPopUp()
    {
        GameObject tutorialPopUp = SRResources.Core.UI.TutorialPopup.Instantiate();
        tutorialPopUp.transform.SetParent(gameObject.transform, false);
        _tutorialPopUp = tutorialPopUp.GetComponent<TutorialPopUp>();
        _tutorialPopUp.Initialize();
        return this;
    }

    private RoachCount _roachCount;
    private DashMeter _dashMeter;
    private EndScreen _endScreen;
    private AlertPopUp _alertPopUp;
    private LoadingScreen _loadingScreen;
    private TutorialPopUp _tutorialPopUp;
}
