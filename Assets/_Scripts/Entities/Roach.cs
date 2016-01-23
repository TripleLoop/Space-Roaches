using System;
using UnityEngine;
using System.Collections;

//TODO: should move, try not to create chaos in game
public class Roach : MonoBehaviourEx, IKillable, IWakeable
{
    private Rigidbody2D _rigidbody2D;
    private bool _hasInitialized;

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
        else Reset();
        _currentState = Idle;
        StartCoroutine(Spawn());
    }

    public void Kill()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.RoachSplat));
        Messenger.Publish(new RoachDeathMessage(gameObject));
        SetState(State.Death);
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnRoachParticleMessage(gameObject));
        yield return new WaitForSeconds(0.2f);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
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
                break;
            case State.Death:
                _currentState = Death;
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

    private void Reset()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public Roach Initialize()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        _hasInitialized = true;
        return this;
    }
  
}
