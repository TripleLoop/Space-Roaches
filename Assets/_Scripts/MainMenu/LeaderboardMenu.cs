using UnityEngine;
using System.Collections;

public class LeaderboardMenu : MonoBehaviour {

    private MenuCanvas.EnableDelegate _enableDelegate;

    public LeaderboardMenu Show(MenuCanvas.EnableDelegate enableDelegate)
    {
        EnableChildren();
        _enableDelegate = enableDelegate;
        return this;
    }

    //Function executed on pressing popup x button
    public void Close()
    {
        DisableChildren();
        _enableDelegate();
    }

    private LeaderboardMenu EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    private LeaderboardMenu DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }

}
