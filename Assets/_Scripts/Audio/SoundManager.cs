using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviourEx, IHandle<PlaySoundEffectMessage>, IHandle<PlayMusicMessage>
{
    private GameObject _soundEffects;
    private GameObject _music;

	// Use this for initialization
	void Start ()
	{
	    _soundEffects = SRResources.Core.Audio._Prefabs.SoundEffects.Instantiate();
        _music = SRResources.Core.Audio._Prefabs.Music.Instantiate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(PlaySoundEffectMessage message)
    {
        AudioSource soundEffectsSource = _soundEffects.GetComponent<AudioSource>();
        soundEffectsSource.clip = message.SoundEffectClip;
        soundEffectsSource.Play();
    }

    public void Handle(PlayMusicMessage message)
    {
        AudioSource musicSource = _music.GetComponent<AudioSource>();
        musicSource.clip = message.MusicClip;
        musicSource.Play();
    }
}
