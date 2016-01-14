﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LocalConfig = Config.EndScreen;

public class EndScreen : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{
    private Text _textCount;
    private Text _textComment;

    private RoachCount _roachCount;

    private bool _isInCountUp;
    private IEnumerator _countUp;

    private bool _astronautDead = false;
    private Animator _animator;

    private TypeWriting _typeWriting;
    private SelectEndScreenText _selectEndScreenText;
    private List<RangeComments> _rangeComments = LocalConfig.AllRangesComments;

    public EndScreen Initialize(RoachCount roachCount)
    {
        if (roachCount == null) return this;
        _roachCount = roachCount;
        _textCount = GetComponentsInChildren<Text>(true)[0];
        _textComment = GetComponentsInChildren<Text>(true)[1];
        _typeWriting = gameObject.AddComponent<TypeWriting>();
        _selectEndScreenText = new SelectEndScreenText();
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
        if (_animator.GetInteger("EndState") == 2)
        {
            _animator.SetInteger("EndState", 0);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            _textComment.text = "";
            _textCount.text = "0";
        }
        if (_animator.GetInteger("EndState") == 1)
        {
            _countUp = CountUp();
            StartCoroutine(_countUp);
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
        }
    }

    public EndScreen Reset()
    {
        _astronautDead = false;
        _typeWriting.StopWriting();
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
        Messenger.Publish(new NewScoreMessage(numDeathRoaches));
        while (true)
        {
            if (scoreCount == numDeathRoaches)
            {
                _isInCountUp = false;
                WriteComment(numDeathRoaches);
                break;
            }
            yield return new WaitForSeconds(0.05f);
            scoreCount++;
            _textCount.text = scoreCount.ToString();
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.tick));
        }
        
    }

    private void Start()
    {
        Initialize();
    }

    public EndScreen WriteComment(int deathRoaches)
    {
        _typeWriting.StartWrite(_selectEndScreenText.CommentByScore(deathRoaches, _rangeComments), _textComment);
        return this;
    }
}
