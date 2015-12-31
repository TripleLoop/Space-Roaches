using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx, IHandle<RequestAudioStateMessage>, IHandle<AudioStateMessage>
{
    private float _effectsVolume;
    private float _musicVolume;
    private int _tutorialSeen;

    public PlayerPrefsManager Initialize()
    {
        InitializeKeys().
        InitializeValues();
        return this;
    }

    public bool HasSeenTutorial()
    {
        if (_tutorialSeen == 0)
        {
            _tutorialSeen = 1;
            PlayerPrefs.SetInt("_tutorialSeen", 1);
            return false;
        }
        return true;
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
        _tutorialSeen = PlayerPrefs.GetInt("_tutorialSeen");
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
        if (!PlayerPrefs.HasKey("_tutorialSeen"))
        {
            PlayerPrefs.SetInt("_tutorialSeen", 0);
        }
        return this;
    }

}
