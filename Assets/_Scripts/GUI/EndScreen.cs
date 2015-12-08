using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreen : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{
    private Text _text;
    [SerializeField]
    private Text _roachesDeath;

    private bool _isInCountUp;
    private IEnumerator _countUp;

    private bool _astronautDead = false;


	void Start ()
	{
	    _text = GetComponentsInChildren<Text>(true)[0];
	}

    public EndScreen Reset()
    {
        _astronautDead = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        if (_isInCountUp)
        {
            StopCoroutine(_countUp);
        }
        return this;
    }

    public void Menu()
    {
        Debug.Log("Menu");
    }

    public void Restart()
    {
        Messenger.Publish(new RestartGameMessage());
    }

    public void Handle(AstronautDeathMessage message)
    {
        if (!_astronautDead)
        {
            _astronautDead = true;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            _countUp = CountUp();
            StartCoroutine(_countUp);
        }
    }

    private IEnumerator CountUp()
    {
        _isInCountUp = true;
        int scoreCount = 0;
        int numDeathRoaches = int.Parse(_roachesDeath.text);

        while (true)
        {
            if (scoreCount >= numDeathRoaches)
            {
                break;
            }
            yield return new WaitForSeconds(0.05f);
            scoreCount++;
            _text.text = ""+scoreCount;
        }
        _isInCountUp = false;
    }

    
}
