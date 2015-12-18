using UnityEngine;
using System.Collections;

public class PlaySoundEffectMessage
{
    public AudioClip SoundEffectClip;
    public bool Tracked;

    public PlaySoundEffectMessage(AudioClip soundEffectClip, bool tracked = false)
    {
        this.SoundEffectClip = soundEffectClip;
        Tracked = tracked;
    }
}
