using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using LocalConfig = Config.Entities.Spikeball;

public class DeathBall : MonoBehaviour
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

    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        Debug.Log("sadsad");
        _currentState = Idle;
        SetState(State.Moving);
    }

}
