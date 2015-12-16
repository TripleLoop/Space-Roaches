public class AudioStateMessage {

    public float FxVolume { get; set; }
    public float MusicVolume { get; set; }

    public AudioStateMessage(float fxVolume, float musicVolume)
    {
        FxVolume = fxVolume;
        MusicVolume = musicVolume;
    }
}
