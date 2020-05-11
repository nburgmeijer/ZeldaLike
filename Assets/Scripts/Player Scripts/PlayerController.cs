using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private IPlayerState _currentState;
    private IPlayerState _lastState;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidBody;
    private bool _canMove = true;
    private PlayerControls _playerControls;
    private InputAction _moveAction;
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
        _moveAction = _playerControls.PlayerControlsActionMap.Move;
        _moveAction.performed += OnMove;
        _moveAction.canceled += OnEndMove;
        _moveAction.Enable();
        IdleState = new PlayerIdleState();
        MoveState = new PlayerMoveState();
    }

    private void OnEndMove(InputAction.CallbackContext context)
    {
        _change = Vector2.zero;
        TransitionToState(IdleState);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _change = context.ReadValue<Vector2>();
        TransitionToState(MoveState);
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
        _lastState = _currentState;
        _currentState = state;
        _currentState.EnterState(this);
    }
}
