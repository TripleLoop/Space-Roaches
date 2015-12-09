using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx
{
    private bool fxMuted;
    private bool musicMuted;

    private void Start()
    {
        InitializeKeys().
        InitializeValues();
    }

    private PlayerPrefsManager InitializeValues()
    {
        fxMuted = PlayerPrefs.GetInt("fxMuted") != 0;
        musicMuted = PlayerPrefs.GetInt("musicMuted") != 0;
        return this;
    }

    private PlayerPrefsManager InitializeKeys()
    {
        if (!PlayerPrefs.HasKey("fxMuted"))
        {
            PlayerPrefs.SetInt("fxMuted", 0);
        }
        if (!PlayerPrefs.HasKey("musicMuted"))
        {
            PlayerPrefs.SetInt("musicMuted", 0);
        }
        return this;
    }
   
	
}
