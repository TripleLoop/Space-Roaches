using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPrefsManager : MonoBehaviourEx, IHandle<RequestAudioStateMessage>, IHandle<AudioStateMessage>, IHandle<NewScoreMessage>
{
    private float _effectsVolume;
    private float _musicVolume;
    private int _tutorialSeen;
    private int _ownHighScore;
    private int _scorePublished;

    public PlayerPrefsManager Initialize()
    {
        InitializeKeys().
        InitializeValues();
        return this;
    }

    public int GetScore()
    {
        return _ownHighScore;
    }

    public bool TutorialSeen
    {
        get { return _tutorialSeen == 1; }
        set
        {
            _tutorialSeen = value ? 1 : 0;
            PlayerPrefs.SetInt("_tutorialSeen", _tutorialSeen);
        }
    }

    public bool ScorePublished
    {
        get { return _scorePublished == 1; }
        set
        {
            _scorePublished = value ? 1 : 0;
            PlayerPrefs.SetInt("_scorePublished", _scorePublished);
        }
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

    public void Handle(NewScoreMessage message)
    {
        if (message.Score > _ownHighScore)
        {
            PlayerPrefs.SetInt("_ownHighScore", message.Score);
            ScorePublished = false;
        }
    }

    private PlayerPrefsManager InitializeValues()
    {
        _effectsVolume = PlayerPrefs.GetFloat("_effectsVolume");
        _musicVolume = PlayerPrefs.GetFloat("_musicVolume");
        _tutorialSeen = PlayerPrefs.GetInt("_tutorialSeen");
        _ownHighScore = PlayerPrefs.GetInt("_ownHighScore");
        _scorePublished = PlayerPrefs.GetInt("_scorePublished");
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
        if (!PlayerPrefs.HasKey("_ownHighScore"))
        {
            PlayerPrefs.SetInt("_ownHighScore", 0);
        }
        if (!PlayerPrefs.HasKey("_scorePublished"))
        {
            PlayerPrefs.SetInt("_scorePublished", 0);
        }
        return this;
    }
  
}
