public class AudioStateMessage {

    public bool FxMuted { get; set; }
    public bool MusicMuted { get; set; }

    public AudioStateMessage(bool fxMuted,bool musicMuted)
    {
        FxMuted = fxMuted;
        MusicMuted = musicMuted;
    }
}
