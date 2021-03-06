﻿using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using LocalConfig = Config.Entities.Pizza;

public class Pizza : MonoBehaviourEx, IWakeable
{

    private Rigidbody2D _rigidbody2D;
    private bool _hasInitialized;

    private float _pushForce = LocalConfig.PushForce;

    public enum State
    {
        Idle,
        Moving,
        Death,
    }

    private Action _currentState;
    public State CurrentStateName;

    public void WakeUp()
    {
        if (!_hasInitialized) Initialize();
        SetState(State.Moving);
    }

    private void SetState(State state)
    {
        CurrentStateName = state;
        switch (state)
        {
            case State.Idle:
                _currentState = Idle;
                break;

            case State.Moving:
                _currentState = Moving;
                _rigidbody2D.AddForce(Random_dir() * _pushForce, ForceMode2D.Impulse);
                break;
            case State.Death:
                _currentState = Death;
                _rigidbody2D.velocity = Vector2.zero;
                break;
            default:
                Debug.Log("unrecognized state");
                break;
        }
    }

    private void Idle()
    {

    }

    private void Moving()
    {

    }

    private void Death()
    {

    }

    private Vector2 Random_dir()
    {
        var randomX = Random.Range(LocalConfig.MinDirectionX, LocalConfig.MaxDirectionX);
        var randomY = Random.Range(LocalConfig.MinDirectionY, LocalConfig.MaxDirectionY);
        return new Vector2(randomX, randomY);
    }

    private void Update()
    {
        _currentState();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(SRTags.Player))
        {
            Messenger.Publish(new PizzaEatenMessage(gameObject));
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.GetPizza));
        }
    }

    public Pizza Initialize()
    {
        _currentState = Idle;
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        InitializePizzaAura();
        _hasInitialized = true;
        return this;
    }

    private Pizza InitializePizzaAura()
    {
        GameObject pizzaAuraParticle = SRResources.Core.Particles._PizzaAura.Instantiate();
        pizzaAuraParticle.transform.parent = gameObject.transform;
        pizzaAuraParticle.transform.localPosition = Vector3.zero;
        return this;
    }

}
