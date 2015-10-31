using System;
using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviour
{

    #region Variables

        private Rigidbody2D _rigidbody2D;

        //Define Stats Machine's variables

        public enum State
        {
            Idle,
            Pulse,
            Moving,
            Die,
        }

        private Action _currentState;
        public State CurrentStateName;

    #endregion

    #region state machine

    public void SetState(State state)
    {
        stateExit(CurrentStateName);
        CurrentStateName = state;
        switch (state)
        {
            case State.Idle:
                _currentState = Idle;
                break;
            case State.Pulse:
                _currentState = Pulse;
                break;
            case State.Moving:
                _currentState = Moving;
                break;
            case State.Die:
                _currentState = Die;
                break;
            default:
                Debug.Log("unrecognized state");
                break;

        }
    }

    public void stateExit(State state)
    {
        switch (state)
        {
            case State.Idle:

                break;
            case State.Pulse:

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

#endregion

    #region States

        private void Idle()
        {
        
        }

        private void Pulse()
        {
        
        }

        private void Moving()
        {
        
        }

        private void Die()
        {
        
        }

    #endregion

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        CurrentStateName = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState();
    }
}
