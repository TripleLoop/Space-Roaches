public class AudioSetUpMessage  {

    public float? EffectsVolume { get; set; }
    public float? MusicVolume { get; set; }

    public AudioSetUpMessage(float? effectsVolume, float? musicVolume)
    {
        EffectsVolume = effectsVolume;
        MusicVolume = musicVolume;
    }
}
