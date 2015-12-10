using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx, IHandle<RequestAudioStateMessage>
{
    private bool _fxMuted;
    private bool _musicMuted;

    private void Start()
    {
        InitializeKeys().
        InitializeValues();
    }

    public void Handle(RequestAudioStateMessage message)
    {
        Messenger.Publish(new AudioStateMessage(_fxMuted, _musicMuted));
    }

    private PlayerPrefsManager InitializeValues()
    {
        _fxMuted = PlayerPrefs.GetInt("_fxMuted") != 0;
        _musicMuted = PlayerPrefs.GetInt("_musicMuted") != 0;
        return this;
    }

    private PlayerPrefsManager InitializeKeys()
    {
        if (!PlayerPrefs.HasKey("_fxMuted"))
        {
            PlayerPrefs.SetInt("_fxMuted", 0);
        }
        if (!PlayerPrefs.HasKey("_musicMuted"))
        {
            PlayerPrefs.SetInt("_musicMuted", 0);
        }
        return this;
    }


    
}
