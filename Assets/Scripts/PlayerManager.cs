using UnityEngine;

public enum State
{
    IDLE,
    WALKING,
    ATTACKING
}

//this class manages player states, and if its allowed to do certain things
public class PlayerManager : MonoBehaviour
{
    private State _currentState = State.IDLE;
    private State _lastState;
    private bool _canMove = true;

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

    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

}
