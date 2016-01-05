using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviourEx, IHandle<AstronautDeathMessage>, IHandle<EndScreenTextSelected>
{
    private Text _textCount;
    private Text _text;

    private RoachCount _roachCount;

    private bool _isInCountUp;
    private IEnumerator _countUp;

    private bool _astronautDead = false;
    private Animator _animator;

    public EndScreen Initialize(RoachCount roachCount)
    {
        if (roachCount == null) return this;
        _roachCount = roachCount;
        _textCount = GetComponentsInChildren<Text>(true)[0];
        _text = GetComponentsInChildren<Text>(true)[1];
        return this;
    }

    public EndScreen Initialize()
    {
        _animator = GetComponent<Animator>();
        return this;
    }

    public void Menu()
    {
        SceneManager.LoadScene(SRScenes.MainMenu);
    }

    public void Restart()
    {
        _animator.SetInteger("EndState", 2);
        Messenger.Publish(new RestartGameMessage());
    }

    public void AnimationEnded()
    {
        _animator.SetInteger("EndState", 0);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Handle(AstronautDeathMessage message)
    {
        if (!_astronautDead)
        {
            _animator.SetInteger("EndState", 1);
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
         var numDeathRoaches = _roachCount.GetScore();
        _textCount.text = scoreCount.ToString();
        Messenger.Publish(new NewScoreMessage(numDeathRoaches));
        while (true)
        {
            if (scoreCount >= numDeathRoaches)
            {
                Messenger.Publish(new ScoreCountFinished(numDeathRoaches));
                break;
            }
            yield return new WaitForSeconds(0.05f);
            scoreCount++;
            _textCount.text = scoreCount.ToString();
        }
        _isInCountUp = false;
    }

    private void Start()
    {
        Initialize();
    }

    public void Handle(EndScreenTextSelected message)
    {
        _text.text = message.Text;
    }
}
