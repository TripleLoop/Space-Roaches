using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashMeter : MonoBehaviourEx, IHandle<UserInputMessage>, IHandle<CanDashQuestion>, IHandle<AstronautDeathMessage>
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

    public void Handle(UserInputMessage message)
    {
        Dash();
    }

    public void Handle(CanDashQuestion message)
    {
        Messenger.Publish(_charges == 0 ? new CanDashAnswers(false) : new CanDashAnswers(true));
    }

    public void Handle(AstronautDeathMessage message)
    {
        StopAllCoroutines();
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

    private void Dash()
    {
        if (_charges > 0)
        {
            _scrollbar.size -= 0.15f;
            UseCharge(_charges);
        }
        StopCoroutine(_loadBar);
        _loadBar = LoadBar();
        StartCoroutine(_loadBar);
    }

    private void AddCharge(int charge)
    {
        for (int i = 0; i < charge; i++)
        {
            Charges[i].sprite = ChargeActive;
        }
    }

    private void UseCharge(int charge)
    {
        for (int i = charge; i <= Charges.Length; i++)
        {
            if (i == 0)
            {
                return;
            }
            Charges[i-1].sprite = ChargeInactive;
        }
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
