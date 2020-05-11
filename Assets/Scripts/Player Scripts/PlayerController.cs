using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private IPlayerState _currentState;
    private IPlayerState _lastState;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidBody;
    private bool _canMove = true;
    private PlayerControls _playerControls;
    private Vector2 _change;

    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    
    public Animator PlayerAnimator { get => _playerAnimator; }
    public Rigidbody2D PlayerRigidBody { get => _playerRigidBody; }
    public float MoveSpeed { get => _moveSpeed; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    
    public Vector3 Change { get => _change; set => _change = value; }
    public PlayerControls PlayerControls { get => _playerControls;}

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
        IdleState = new PlayerIdleState();
        MoveState = new PlayerMoveState();
    }

    void Start()
    {
        TransitionToState(IdleState);
    }

    private void Update()
    {
        _currentState.Update(this);
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        _currentState.OnCollisionEnter(this, collision);
    }

    public void TransitionToState(IPlayerState state)
    {
       // _lastState = _currentState;
        _currentState = state;
        _currentState.EnterState(this);
    }
}
