using System;
using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    private RoachCount _roachCount;
    private DashMeter _dashMeter;
    private EndScreen _endScreen;
    private AlertPopUp _alertPopUp;
    private LoadingScreen _loadingScreen;

    ///TODO: Instantiate all the canvas components to ensure they are loaded
    public CanvasManager Initialize()
    {
        _roachCount = GetComponentInChildren<RoachCount>();
        _dashMeter = GetComponentInChildren<DashMeter>();
        _endScreen = GetComponentInChildren<EndScreen>();
        _endScreen.Initialize(_roachCount);
        InitializeAlertPopUp()
            .InitializeLoadingScreen();
        return this;
    }

    public CanvasManager Reset()
    {
        _roachCount.Reset();
        _dashMeter.Reset();
        _endScreen.Reset();
        return this;
    }

    public CanvasManager ShowLoading(Action callback)
    {
        _loadingScreen.PreSceneLoading(callback);
        return this;
    }

    public CanvasManager HideLoading()
    {
        _loadingScreen.Hide();
        return this;
    }

    private CanvasManager InitializeAlertPopUp()
    {
        GameObject alertPopUp = SRResources.Core.UI.AlertPopUp.Instantiate();
        alertPopUp.transform.SetParent(gameObject.transform,false);
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

}
