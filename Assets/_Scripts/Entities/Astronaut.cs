using System;
using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviourEx, IHandle<UserInputMessage>
{
    private Coroutine _slowDown;
    private bool _enableSlowDown = false;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _location;
    private Vector2 _direction;

    public float Intensity;
    private float _tempIntensity;
    private float _boost;

    private Animator _animatorAst;

    //Define Stats Machine's variables

    public enum State
    {
        Idle,
        Dash,
        Moving,
        Die,
    }

    private Action _currentState;
    public State CurrentStateName;

    private void SetState(State state)
    {
        stateExit(CurrentStateName);
        CurrentStateName = state;
        switch (state)
        {
            case State.Idle:
                _currentState = Idle;
                break;
            case State.Dash:
                _currentState = Pulse;
                
                _animatorAst.SetInteger("State", 1);

                //Quaternion.Euler(0, 30, 0);

                transform.rotation = Quaternion.FromToRotation(transform.parent.right, _direction);

                //transform.rotation = Quaternion.Euler(0, 0, Quaternion.Angle(Quaternion.identity, Quaternion.Euler(new Vector3(_location.x, _location.y, 0)))); 
                //Mathf.Rad2Deg * Mathf.Cos(1 / _direction.x));

                if(_enableSlowDown) StopCoroutine(_slowDown); _enableSlowDown = false;
                _slowDown = StartCoroutine(SlowDown());
                break;
            case State.Moving:
                _currentState = Moving;
                _animatorAst.SetInteger("State", 0);
                Debug.Log("MOVING");
                break;
            case State.Die:
                _currentState = Die;
                break;
            default:
                Debug.Log("unrecognized state");
                break;

        }
    }

    private void stateExit(State state)
    {
        switch (state)
        {
            case State.Idle:

                break;
            case State.Dash:
                
                break;
            case State.Moving:

                break;
            case State.Die:
                
                break;
            default:
                Debug.Log("unrecognized state");
                break;
        }
    }

    private void Idle()
    {
            
    }

    private void Pulse()
    {
        _tempIntensity = Intensity * _boost;
        //transform.Translate(_direction * Time.deltaTime * _tempIntensity);
        transform.Translate(Vector2.right * Time.deltaTime * _tempIntensity);
    }

    private void Moving()
    {
        //transform.Translate(_direction * Time.deltaTime * Intensity);
        transform.Translate(Vector2.right * Time.deltaTime * Intensity);
    }

    private void Die()
    {
        
    }

    public void Handle(UserInputMessage message)
    {
        Debug.Log(message.Location);

        _location = message.Location;

        _direction.x = _location.x - transform.position.x;
        _direction.y = _location.y - transform.position.y;
        _direction.Normalize();

        Debug.Log(_direction);

        SetState(State.Dash);
    }

    private IEnumerator SlowDown()
    {
        _enableSlowDown = true;
        _boost = 4.0f;
        yield return new WaitForSeconds(1);
        while (_boost > 1)
        {
            _boost -= 0.5f;
            yield return new WaitForSeconds(0.2f);
        }
        SetState(State.Moving);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState();
    }

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _animatorAst = gameObject.GetComponent<Animator>();
        Intensity = 0.5f;
        _currentState = Idle;
    }
}
