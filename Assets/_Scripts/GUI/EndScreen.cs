using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{
    private Text _text;

    private RoachCount _roachCount;

    private bool _isInCountUp;
    private IEnumerator _countUp;

    private bool _astronautDead = false;


    public EndScreen Initialize(RoachCount roachCount)
    {
        if (roachCount == null) return this;
        _roachCount = roachCount;
        _text = GetComponentsInChildren<Text>(true)[0];
        return this;
    }

    public EndScreen Initialize()
    {
        return this;
    }

    public void Menu()
    {
        SceneManager.LoadScene(SRScenes.MainMenu);
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

    private IEnumerator CountUp()
    {
        _isInCountUp = true;
        int scoreCount = 0;
        int numDeathRoaches = _roachCount.GetScore();
        _text.text = scoreCount.ToString();

        while (true)
        {
            if (scoreCount >= numDeathRoaches)
            {
                break;
            }
            yield return new WaitForSeconds(0.05f);
            scoreCount++;
            _text.text = scoreCount.ToString();
        }
        _isInCountUp = false;
    }

    private void Start()
    {
        Initialize();
    }
   
}
