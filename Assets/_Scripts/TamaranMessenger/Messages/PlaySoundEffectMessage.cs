using UnityEngine;
using System.Collections;

public class PlaySoundEffectMessage
{
    public AudioClip SoundEffectClip;

    public PlaySoundEffectMessage(AudioClip soundEffectClip)
    {
        this.SoundEffectClip = soundEffectClip;
    }
}
