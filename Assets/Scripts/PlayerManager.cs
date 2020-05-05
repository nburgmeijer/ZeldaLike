using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    IDLE,
    WALKING,
    ATTACKING
}

public  class PlayerManager : MonoBehaviour
{
  
    private State _currentState;
    private State _lastState;
    private bool _canMove;
    public State States { get; set; }

    public State CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _lastState = _currentState;
            _currentState = value;
        }
    }

    public State LastState
    {
        get { return _lastState; }
    }

    public bool CanMove;

    private void Awake()
    {
        CurrentState = State.IDLE;
        _canMove = true;
    }
}
