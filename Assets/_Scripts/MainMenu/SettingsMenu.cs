using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    private MenuCanvas.EnableDelegate _enableDelegate;

    public SettingsMenu Show(MenuCanvas.EnableDelegate enableDelegate)
    {
        EnableChildren();
        _enableDelegate = enableDelegate;
        return this;
    }

    //Fucntion executed on pressing popup x button
    public void Close()
    {
        DisableChildren();
        _enableDelegate();
    }

    private SettingsMenu EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    private SettingsMenu DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }

}
