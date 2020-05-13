using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _swordDown; 

    #region Fields
    private PlayerStateBase _currentState;
    private PlayerStateBase _lastState;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidBody;
    private PlayerControls _playerControls;
    private Collider2D _swordDownCollider;

    private Coroutine _coroutine;
    private bool _canMove = true;
    private Vector2 _change;
    
    #endregion

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerMoveState MoveState = new PlayerMoveState();
    public readonly PlayerAttackState AttackState = new PlayerAttackState();

    #region Properties
    public Animator PlayerAnimator { get => _playerAnimator; }
    public Rigidbody2D PlayerRigidBody { get => _playerRigidBody; }
    public float MoveSpeed { get => _moveSpeed; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public Vector3 Change { get => _change; set => _change = value; }
    public PlayerControls PlayerControls { get => _playerControls; }
    public PlayerStateBase LastState { get => _lastState; }
    public Collider2D SwordDownCollider { get => _swordDownCollider; }
    #endregion

    private void Awake()
    {
        _swordDownCollider = _swordDown.GetComponent<Collider2D>();

        _playerAnimator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
        
        _playerControls.PlayerControlsActionMap.Move.performed += OnMove;
        _playerControls.PlayerControlsActionMap.Move.canceled += OnEndMove;
        _playerControls.PlayerControlsActionMap.Move.Enable();

        _playerControls.PlayerControlsActionMap.Attack.performed += OnAttack;
        _playerControls.PlayerControlsActionMap.Attack.Enable();

        EventManager<RoomSwitchEventInfo>.RegisterListener(OnRoomSwitch);
        EventManager<BlendingEndEventInfo>.RegisterListener(OnBlendingEnd);

        
    }

    void Start()
    {
        _currentState = IdleState;
        TransitionToState(IdleState);    
    }

    //private void Update()
    //{   
    //    _currentState.Update(this);
    //}

    void FixedUpdate()
    {
        _currentState.FixedUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        _currentState.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentState.OnTriggerEnter(this, collision);
    }

    public void TransitionToState(PlayerStateBase state)
    {
        _lastState = _currentState;
        _currentState = state;
        _currentState.EnterState(this);
    }

    public void StartExternalCoroutine(IEnumerator coroutine)
    {
        _coroutine = StartCoroutine(coroutine);
                
    }

    #region Callback Methods
    private void OnRoomSwitch(RoomSwitchEventInfo Eventinfo)
    {
        _canMove = false;
    }

    private void OnBlendingEnd(BlendingEndEventInfo Eventinfo)
    {
        _canMove = true;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        TransitionToState(AttackState);   
    }


    private void OnMove(InputAction.CallbackContext context)
    {
        _change = context.ReadValue<Vector2>();
        TransitionToState(MoveState);

    }

    private void OnEndMove(InputAction.CallbackContext context)
    {
        _change = Vector2.zero;
         TransitionToState(IdleState);

    }
        
    #endregion
}
