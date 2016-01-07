using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using LocalConfig = Config.Entities.Spikeball;

public class DeathBall : MonoBehaviourEx, IKillable
{
    private Rigidbody2D _rigidbody2D;

    private float _pushForce = LocalConfig.PushForce;

    public enum State
    {
        Idle,
        Moving,
        Death,
    }

    private Action _currentState;
    public State CurrentStateName;

    public void Kill()
    {
        Messenger.Publish(new SpikeBallDeathMessage(gameObject));
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
                _rigidbody2D.AddForce(Random_dir()*_pushForce);
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

    private new void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _currentState = Idle;
        SetState(State.Moving);
    }

    private Vector2 Random_dir()
    {
        var randomX = Random.Range(LocalConfig.MinDirectionX, LocalConfig.MaxDirectionX);
        var randomY = Random.Range(LocalConfig.MinDirectionY, LocalConfig.MaxDirectionY);
        return new Vector2(randomX, randomY);
    }


}
