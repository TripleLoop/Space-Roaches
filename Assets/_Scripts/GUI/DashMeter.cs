using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashMeter : MonoBehaviourEx, IHandle<CanDashQuestion>, IHandle<AstronautDeathMessage>, IHandle<AstronautImmortalityMessage>
{
    [SerializeField]
    public Image[] Charges;
    private Scrollbar _scrollbar;
    
    private int _charges;

    [SerializeField]
    private Sprite ChargeActive;
    [SerializeField]
    private Sprite ChargeInactive;

    private IEnumerator _loadBar;

    private bool _immortal = false;

    // Use this for initialization
    void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
        _loadBar = LoadBar();
        StartCoroutine(_loadBar);
    }

    public DashMeter Reset()
    {
        _scrollbar.size = 100;
        AddCharge(5);
        CheckCharges();
        _loadBar = LoadBar();
        StartCoroutine(_loadBar);
        return this;
    }

    public void Handle(CanDashQuestion message)
    {
        Dash();
    }

    public void Handle(AstronautDeathMessage message)
    {
        StopAllCoroutines();
    }

    public void Handle(AstronautImmortalityMessage message)
    {
        Reset();
        _immortal = message.Immortal;
    }

    private IEnumerator LoadBar()
    {
        while (_scrollbar.size < 1.0f)
        {
            yield return new WaitForSeconds(0.025f);
            _scrollbar.size += 0.0025f;
            CheckCharges();
            AddCharge(_charges);
        }
    }

    private DashMeter Dash()
    {
        if (_charges == 0)
        {
            Messenger.Publish(new CanDashAnswers(false));
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicCancel, true));
            return this;
        }

        Messenger.Publish(new CanDashAnswers(true));
        if (_immortal)
        {
            return this;
        }
        _scrollbar.size -= 0.15f;
        UseCharge(_charges);
        StopCoroutine(_loadBar);
        _loadBar = LoadBar();
        StartCoroutine(_loadBar);
        return this;

    }

    private void AddCharge(int charge)
    {
        for (int i = 0; i < charge; i++)
        {
            Charges[i].sprite = ChargeActive;
        }
    }

    private DashMeter UseCharge(int charge)
    {
        for (int i = charge; i <= Charges.Length; i++)
        {
            if (i == 0)
            {
                return this;
            }
            Charges[i-1].sprite = ChargeInactive;
        }
        return this;
    }

    private void CheckCharges()
    {
        if (_scrollbar.size >= 0.98f)
        {
            _charges = 5;
            return;
        }
        if (_scrollbar.size >= 0.85f)
        {
            _charges = 4;
            return;
        }
        if (_scrollbar.size >= 0.70f)
        {
            _charges = 3;
            return;
        }
        if (_scrollbar.size >= 0.55f)
        {
            _charges = 2;
            return;
        }
        if (_scrollbar.size >= 0.40f)
        {
            _charges = 1;
            return;
        }
        else
        {
            _charges = 0;
            return;
        }
    }
}
