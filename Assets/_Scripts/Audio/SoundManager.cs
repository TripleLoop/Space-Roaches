using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviourEx, IHandle<PlaySoundEffectMessage>, IHandle<PlayMusicMessage>
{
    private GameObject _soundEffects;
    private GameObject _music;

    public SoundManager SetAudioState()
    {
        return this;
    }

	public SoundManager InitializeSources()
    {
        _soundEffects = SRResources.Core.Audio._Prefabs.SoundEffects.Instantiate();
        _soundEffects.transform.SetParent(this.gameObject.transform, false);

        _music = SRResources.Core.Audio._Prefabs.Music.Instantiate();
        _music.transform.SetParent(this.gameObject.transform, false);
        return this;
    }

    public void Handle(PlaySoundEffectMessage message)
    {
        AudioSource soundEffectsSource = _soundEffects.GetComponent<AudioSource>();
        soundEffectsSource.PlayOneShot(message.SoundEffectClip);
    }

    public void Handle(PlayMusicMessage message)
    {
        AudioSource musicSource = _music.GetComponent<AudioSource>();
        musicSource.clip = message.MusicClip;
        musicSource.Play();
    }
}
