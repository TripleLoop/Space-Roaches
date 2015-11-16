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
    private Vector2 _bouncePosition;

    private float _intensity = 4.0f;
    private float _breakIntensity = 2.0f;

    private Animator _animatorAst;

    private int _scale = 1;

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
                _currentState = Dash;
                
                _animatorAst.SetInteger("State", 1);

                //Quaternion.Euler(0, 30, 0);
                
                transform.rotation = Quaternion.FromToRotation(transform.parent.right, _direction);

                _rigidbody2D.velocity = Vector2.zero;
                //_rigidbody2D.angularVelocity = 0;
                _rigidbody2D.AddForce(_direction * _intensity, ForceMode2D.Impulse);
                FlipChar();

                //transform.rotation = Quaternion.Euler(0, 0, Quaternion.Angle(Quaternion.identity, Quaternion.Euler(new Vector3(_location.x, _location.y, 0)))); 
                //Mathf.Rad2Deg * Mathf.Cos(1 / _direction.x));

                if (_enableSlowDown) StopCoroutine(_slowDown); _enableSlowDown = false;
                _slowDown = StartCoroutine(SlowDown());
                break;
            case State.Moving:
                _currentState = Moving;

                _animatorAst.SetInteger("State", 0);

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

    private void Dash()
    {
        //transform.Translate(Vector2.right * Time.deltaTime * _tempIntensity);
        _rigidbody2D.AddForce(-_direction * _breakIntensity);
    }

    private void Moving()
    {
        //transform.Translate(_direction * Time.deltaTime * _intensity);
    }

    private void Die()
    {
        
    }

    public void Handle(UserInputMessage message)
    {

        _location = message.Location;

        _direction.x = _location.x - transform.position.x;
        _direction.y = _location.y - transform.position.y;
        _direction.Normalize();

        SetState(State.Dash);
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        Vector2 bouncePos = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine(BounceDirection(bouncePos));
    }

    private IEnumerator SlowDown()
    {
        _enableSlowDown = true;
        yield return new WaitForSeconds(1);
        SetState(State.Moving);
    }

    private void FlipChar()
    {
        Debug.Log(_direction);
        if (_direction.x < 0)
        {
            _scale = -1;
        }
        else
        {
            _scale = 1;
        }
        Debug.Log(transform.rotation.y);
        if (transform.rotation.y == 1)
        {
            _scale = -_scale;
        }
        transform.localScale = new Vector3(1, _scale, 1);
    }

    private IEnumerator BounceDirection(Vector2 bPos)
    {
        yield return null;
        Vector2 tempPos = new Vector2(transform.position.x, transform.position.y);

        Debug.Log(tempPos + " - " + bPos);

        _direction = tempPos - bPos;
        
        transform.rotation = Quaternion.FromToRotation(transform.parent.right, _direction);
        FlipChar();
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
        _currentState = Idle;
    }
}
