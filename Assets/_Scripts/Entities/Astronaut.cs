using System;
using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviourEx, IHandle<UserInputMessage>, IHandle<ChargesAnswers>, IHandle<PizzaEatenMessage>
{
    private Coroutine _slowDown;
    private bool _enableSlowDown = false;
    private bool _canDash;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _location;
    private Vector2 _direction;
    private Vector2 _bouncePosition;

    private float _intensity = 4.0f;
    private float _breakIntensity = 0.9f;

    private Animator _animatorAst;

    private float _scale;

    private bool _immortal = false;

    private bool _astronautDead = false;

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

                if (_enableSlowDown)
                {
                    StopCoroutine(_slowDown);
                    _enableSlowDown = false;
                }
                _slowDown = StartCoroutine(SlowDown());
                break;
            case State.Moving:
                _currentState = Moving;

                _animatorAst.SetInteger("State", 0);

                break;
            case State.Die:
                _currentState = Die;
                Messenger.Publish(new AstronautDeathMessage(gameObject));
                _astronautDead = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().isKinematic = true;
                //Debug.Log("Die");
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
        //Debug.Log("Vector direction" + _direction);
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
        if (!_astronautDead)
        {
            Messenger.Publish(new ChargesQuestion());

            if (!_canDash)
            {
                return;
            }

            _location = message.Location;

            _direction.x = _location.x - transform.position.x;
            _direction.y = _location.y - transform.position.y;
            _direction.Normalize();

            SetState(State.Dash);
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollision)
    {
        if (otherCollision.collider.CompareTag(SRTags.Spikeball))
        {
            if (_immortal)
            {
                Messenger.Publish(new SpikeBallDeathMessage(otherCollision.gameObject));
                return;
            }
            SetState(State.Die);
        }
        if (_currentState == Dash)
        {
            Vector2 bouncePos = new Vector2(transform.position.x, transform.position.y);
            StartCoroutine(BounceDirection(bouncePos));
        }
    }

    private IEnumerator SlowDown()
    {
        _enableSlowDown = true;
        //Debug.Log("entro");
        yield return new WaitForSeconds(0.5f);
        while (_rigidbody2D.velocity.magnitude > 2.0f)
        {
            yield return new WaitForSeconds(0.1f);
            _rigidbody2D.velocity *= _breakIntensity;
        }
        
        SetState(State.Moving);
    }

    private void FlipChar()
    {
        float scale;
        //Debug.Log(_direction);
        if (_direction.x < 0)
        {
            scale = -_scale;
        }
        else
        {
            scale = _scale;
        }
        //Debug.Log(transform.rotation.y);
        if (transform.rotation.y >= 1)
        {
            scale = -scale;
        }
        transform.localScale = new Vector3(_scale, scale, _scale);
    }

    private IEnumerator Immortal()
    {
        _immortal = true;
        yield return new WaitForSeconds(3.0f);
        _immortal = false;
    }

    private IEnumerator BounceDirection(Vector2 bPos)
    {
        yield return null;
        Vector2 tempPos = new Vector2(transform.position.x, transform.position.y);

        //Debug.Log(tempPos + " - " + bPos);

        _direction = tempPos - bPos;

        _direction.Normalize();

        //Debug.Log("Vector rebote:" + _direction);
        
        transform.rotation = Quaternion.FromToRotation(transform.parent.right, _direction);
        FlipChar();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState();
        //Debug.Log("Vector: " + _rigidbody2D.velocity + "|| Magnitude: " + _rigidbody2D.velocity.magnitude);
    }

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _animatorAst = gameObject.GetComponent<Animator>();
        SetState(State.Idle);
        _scale = transform.localScale.y;
    }

    public void Handle(ChargesAnswers message)
    {
        _canDash = message.Answer;
    }

    public void Handle(PizzaEatenMessage message)
    {
        StartCoroutine(Immortal());
    }

    public Astronaut Reset()
    {
        //set stating values
        SetState(State.Idle);
        _scale = transform.localScale.y;
        _astronautDead = false;
        transform.position = new Vector2(0, 0);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        return this;
    }


}
