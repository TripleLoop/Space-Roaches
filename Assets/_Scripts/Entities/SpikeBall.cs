using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using LocalConfig = Config.Entities.Spikeball;

public class SpikeBall : MonoBehaviourEx, IKillable, IWakeable
{
    private Rigidbody2D _rigidbody2D;
    private bool hasInitialized;

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
        if (!hasInitialized) Initialize();
        StartCoroutine(Spawn());
        _currentState = Idle;
    }

    public void Kill()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.SpikeExplosion));
        Messenger.Publish(new SpikeBallDeathMessage(gameObject));
        SetState(State.Death);
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnSpikeBallParticleMessage(gameObject));
        yield return new WaitForSeconds(2.0f);
        
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponentsInChildren<Collider2D>()[1].enabled = true;
        
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

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag(SRTags.Player))
        {
            otherCollider.GetComponent<Astronaut>().Kill();
            return;
        }
    }

    private SpikeBall Initialize()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        
        hasInitialized = true;
        return this;
    }
}


