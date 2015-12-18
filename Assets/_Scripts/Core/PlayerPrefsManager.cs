using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx, IHandle<RequestAudioStateMessage>
{
    private float _fxVolume;
    private float _musicVolume;

    private void Start()
    {
        InitializeKeys().
        InitializeValues();
    }

    public void Handle(RequestAudioStateMessage message)
    {
        Messenger.Publish(new AudioStateMessage(_fxVolume, _musicVolume));
    }

    private PlayerPrefsManager InitializeValues()
    {
        _fxVolume = PlayerPrefs.GetFloat("_fxVolume");
        _musicVolume = PlayerPrefs.GetFloat("_musicVolume");
        return this;
    }

    private PlayerPrefsManager InitializeKeys()
    {
        if (!PlayerPrefs.HasKey("_fxVolume"))
        {
            PlayerPrefs.SetFloat("_fxVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("_musicVolume"))
        {
            PlayerPrefs.SetFloat("_musicVolume", 1f);
        }
        return this;
    }


    
}
