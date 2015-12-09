using UnityEngine;
using System.Collections;

public class PlayMusicMessage {

    public AudioClip MusicClip;

    public PlayMusicMessage(AudioClip musicClip)
    {
        this.MusicClip = musicClip;
    }
}
