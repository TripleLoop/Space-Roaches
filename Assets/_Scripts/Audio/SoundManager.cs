using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviourEx, IHandle<PlaySoundEffectMessage>, IHandle<PlayMusicMessage>, IHandle<AudioStateMessage>, IHandle<AudioSetUpMessage>
{
    private AudioMixer _audioMixer;

    private GameObject _soundEffects;
    private GameObject _music;

    private float _startTime;
    private AudioClip _cancelClip;

    public SoundManager SetAudioState()
    {
        Messenger.Publish(new RequestAudioStateMessage());
        return this;
    }

    public SoundManager InitializeSources()
    {
        _soundEffects = SRResources.Core.Audio._Prefabs.SoundEffects.Instantiate();
        _soundEffects.transform.SetParent(this.gameObject.transform, false);

        _music = SRResources.Core.Audio._Prefabs.Music.Instantiate();
        _music.transform.SetParent(this.gameObject.transform, false);

        _cancelClip = SRResources.Core.Audio.Clips.SoundEffects.BasicCancel;

        _audioMixer = GetComponentInChildren<AudioSource>().outputAudioMixerGroup.audioMixer;
        return this;
    }

    public void Handle(PlaySoundEffectMessage message)
    {
        if (_soundEffects == null)
        {
            return;
        }
        AudioSource soundEffectsSource = _soundEffects.GetComponent<AudioSource>();
        if (message.Tracked)
        {
            if (IsPlaying())
            {
                return;
            }
            _startTime = Time.time;
        }
        soundEffectsSource.PlayOneShot(message.SoundEffectClip);
    }

    public void Handle(PlayMusicMessage message)
    {
        if (_music == null)
        {
            return;
        }
        AudioSource musicSource = _music.GetComponent<AudioSource>();
        musicSource.clip = message.MusicClip;
        musicSource.Play();
    }

    public void Handle(AudioStateMessage message)
    {
        SetVolume(message.EffectsVolume, message.MusicVolume);
    }

    public void Handle(AudioSetUpMessage message)
    {
        SetVolume(message.EffectsVolume, message.MusicVolume);
    }

    private SoundManager SetVolume(float? effectsVolume, float? musicVolume)
    {
        if (_audioMixer == null)
        {
            return this;
        }
        if (effectsVolume != null)
        {
            _audioMixer.SetFloat("effectsVolume", AudioLevelBalancer(effectsVolume.Value));
        }
        if (musicVolume != null)
        {
            _audioMixer.SetFloat("musicVolume", AudioLevelBalancer(musicVolume.Value));
        }
        return this;
    }

    private bool IsPlaying()
    {
        if ((Time.time - _startTime) >= _cancelClip.length)
            return false;
        return true;
    }

    /// <summary>
    /// Some magic is done to have proper audio levels, if it's a negative number the audio value has to be multiplied by 4
    /// </summary>
    /// <returns>Processed value</returns>
    private float AudioLevelBalancer(float audioVolume)
    {
        if (audioVolume < 0)
        {
            return audioVolume * 4;
        }
        return audioVolume;
    }

}
