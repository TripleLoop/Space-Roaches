using System;
using UnityEngine;
using System.Collections;
using LocalConfig = Config.Entities.Roach;
using Random = UnityEngine.Random;

//TODO: should move, try not to create chaos in game
public class Roach : MonoBehaviourEx, IKillable, IWakeable
{
    private Rigidbody2D _rigidbody2D;
    private bool _hasInitialized;

    private float _pushForce = LocalConfig.PushForce;
    private float _localScaleX;

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
    
    private IEnumerator EndlessPush()
    {
        while (true)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Random_dir() * _pushForce, ForceMode2D.Impulse);
            FlipChar();
            yield return new WaitForSeconds(Random.Range(3f,4f));
        }
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnRoachParticleMessage(gameObject));
        yield return new WaitForSeconds(0.2f);
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
                StartCoroutine(EndlessPush());
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
        StopAllCoroutines();
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        _localScaleX = transform.localScale.x;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentsInChildren<Collider2D>()[1].enabled = false;
    }

    private void FlipChar()
    {
        if (_rigidbody2D.velocity.x <= 0)
        {
            transform.localScale = new Vector2(_localScaleX, transform.localScale.y);
        }

        else
        {
            transform.localScale = new Vector2(-_localScaleX, transform.localScale.y);
        }
    }

    private Vector2 Random_dir()
    {
        var randomX = Random.Range(LocalConfig.MinDirectionX, LocalConfig.MaxDirectionX);
        var randomY = Random.Range(LocalConfig.MinDirectionY, LocalConfig.MaxDirectionY);
        return new Vector2(randomX, randomY);
    }

    public Roach Initialize()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _localScaleX = transform.localScale.x;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentsInChildren<Collider2D>()[1].enabled = false;
        _hasInitialized = true;
        return this;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(SRTags.Wall))
        {
            FlipChar();
        }
    }
}
