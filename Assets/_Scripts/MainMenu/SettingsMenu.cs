using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LocalConfig = Config.Audio;

public class SettingsMenu : MonoBehaviourEx, IHandle<AudioSetUpMessage>
{
    private MenuCanvas.EnableDelegate _enableDelegate;

    [SerializeField]
    private Slider _effectsSlider;
    [SerializeField]
    private Slider _musicSlider;

    private bool _audioSetUp;

    private void Start()
    {
        if (!_audioSetUp)
        {
            Messenger.Publish(new RequestAudioStateMessage());
        }
        _effectsSlider.maxValue = LocalConfig.EffectsSlider.MaxValue;
        _effectsSlider.minValue = LocalConfig.EffectsSlider.MinValue;
        _musicSlider.maxValue = LocalConfig.MusicSlider.MaxValue;
        _musicSlider.minValue = LocalConfig.MusicSlider.MinValue;

    }

    public SettingsMenu Show(MenuCanvas.EnableDelegate enableDelegate)
    {
        EnableChildren();
        _enableDelegate = enableDelegate;
        return this;
    }

    //Function executed on pressing popup x button
    public void Close()
    {
        DisableChildren();
        _enableDelegate();
    }

    //called when slider music moves
    public void OnSliderMusic(float value)
    {
        if (!_audioSetUp) return;
        Messenger.Publish(new AudioStateMessage(null, value));
    }

    //called when slider effects moves 
    public void OnSliderEffects(float value)
    {
        if (!_audioSetUp) return;
        Messenger.Publish(new AudioStateMessage(value, null));
    }

    public void Handle(AudioSetUpMessage message)
    {
        if (message.EffectsVolume != null)
        {
            _effectsSlider.value = message.EffectsVolume.Value;
        }
        if (message.MusicVolume != null)
        {
            _musicSlider.value = message.MusicVolume.Value;
        }
        _audioSetUp = true;
    }

    private SettingsMenu EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    private SettingsMenu DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }

}
