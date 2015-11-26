using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashMeter : MonoBehaviourEx, IHandle<UserInputMessage>, IHandle<ChargesQuestion>
{

    public Image[] Charges;
    private Scrollbar _scrollbar;

    [SerializeField]
    private int _charges;

    public Sprite ChargeActive;
    public Sprite ChargeInactive;

    private Coroutine _loadBar;

    public void Handle(UserInputMessage message)
    {
        Dash();
        /*StartCoroutine(Handler());*/
    }

    /*private IEnumerator Handler()
    {
        yield return StartCoroutine(Dash());
        yield return StartCoroutine(LoadBar());
    }*/

    private IEnumerator LoadBar()
    {
        while (_scrollbar.size < 1f)
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
        _loadBar = StartCoroutine(LoadBar());
        /*float tempSize = _scrollbar.size;
        while (tempSize - _scrollbar.size  < 0.15f)
        {
            Debug.Log(tempSize-_scrollbar.size);
            yield return new WaitForSeconds(0.01f);
            _scrollbar.size -= 0.0025f;
            CheckCharges();
            UseCharge(_charges);
        }*/
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

    // Use this for initialization
    void Start ()
    {
	    _scrollbar = GetComponent<Scrollbar>();
        _loadBar = StartCoroutine(LoadBar());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Handle(ChargesQuestion message)
    {
        Debug.Log("handle"+_charges);
        if (_charges == 0)
        {
            Messenger.Publish(new ChargesAnswers(false));
        }
        else
        {
            Messenger.Publish(new ChargesAnswers(true));
        }
        
    }
}
