using System;
using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviourEx, IHandle<UserInputMessage>, IHandle<CanDashAnswers>, IHandle<PizzaEatenMessage>
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

    // Use this for initialization
    private void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _animatorAst = gameObject.GetComponent<Animator>();
        SetState(State.Idle);
        _scale = transform.localScale.y;
    }

    public Astronaut Reset()
    {
        //set stating values
        SetState(State.Idle);
        _astronautDead = false;
        transform.position = new Vector2(0, 0);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        return this;
    }

    public void Handle(UserInputMessage message)
    {
        
        if (!_astronautDead)
        {
            _location = message.Location;
            Messenger.Publish(new CanDashQuestion());
        }
    }

    public void Handle(CanDashAnswers message)
    {
        if (!message.CanDash)
        {
            return;
        }
        _direction.x = _location.x - transform.position.x;
        _direction.y = _location.y - transform.position.y;
        _direction.Normalize();

        SetState(State.Dash);
    }

    public void Handle(PizzaEatenMessage message)
    {
        StartCoroutine(Immortal());
    }

    private void SetState(State state)
    {
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
                break;
            default:
                Debug.Log("unrecognized state");
                break;

        }
    }

    private void Idle(){}

    private void Dash(){}

    private void Moving(){}

    private void Die(){}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(SRTags.Spikeball))
        {
            if (_immortal)
            {
                Messenger.Publish(new SpikeBallDeathMessage(coll.gameObject));

                return;
            }
            SetState(State.Die);
        }
        if (coll.gameObject.CompareTag(SRTags.Wall))
        {
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.WallHit));
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

    private Astronaut FlipChar()
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
        return this;
    }

    private IEnumerator BounceDirection(Vector2 bPos)
    {
        yield return null;
        Vector2 tempPos = new Vector2(transform.position.x, transform.position.y);

        _direction = tempPos - bPos;

        _direction.Normalize();

        transform.rotation = Quaternion.FromToRotation(transform.parent.right, _direction);
        FlipChar();
    }

    private IEnumerator Immortal()
    {
        _immortal = true;
        yield return new WaitForSeconds(3.0f);
        _immortal = false;
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState();
    }
}
