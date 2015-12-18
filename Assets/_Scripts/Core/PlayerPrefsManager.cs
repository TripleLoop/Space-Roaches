using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx, IHandle<RequestAudioStateMessage>, IHandle<AudioStateMessage>
{
    private float _effectsVolume;
    private float _musicVolume;


    public PlayerPrefsManager Initialize()
    {
        InitializeKeys().
        InitializeValues();
        return this;
    }

    public void Handle(RequestAudioStateMessage message)
    {
        Messenger.Publish(new AudioSetUpMessage(_effectsVolume, _musicVolume));
    }

    public void Handle(AudioStateMessage message)
    {
        if (message.EffectsVolume != null)
        {
            PlayerPrefs.SetFloat("_effectsVolume", message.EffectsVolume.Value);
        }
        if (message.MusicVolume != null)
        {
            PlayerPrefs.SetFloat("_musicVolume", message.MusicVolume.Value);
        }
    }

    private PlayerPrefsManager InitializeValues()
    {
        _effectsVolume = PlayerPrefs.GetFloat("_effectsVolume");
        _musicVolume = PlayerPrefs.GetFloat("_musicVolume");
        return this;
    }

    private PlayerPrefsManager InitializeKeys()
    {
        if (!PlayerPrefs.HasKey("_effectsVolume"))
        {
            PlayerPrefs.SetFloat("_effectsVolume", 0f);
        }
        if (!PlayerPrefs.HasKey("_musicVolume"))
        {
            PlayerPrefs.SetFloat("_musicVolume", 0f);
        }
        return this;
    }

}
