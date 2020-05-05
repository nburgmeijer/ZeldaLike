using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    private PlayerControls _playerControls;
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private Vector3 _change;
    private InputAction _move;
    private PlayerManager _playerManager;

    void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
        _playerControls = new PlayerControls();
        _move = _playerControls.PlayerControlsActionMap.Move;
        _move.performed += OnMove;
        _move.canceled += OnMove;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        EventManager<RoomSwitchEventInfo>.RegisterListener(OnRoomSwitch);
        EventManager<BlendingEndEventInfo>.RegisterListener(OnBlendingEnd);
    }
    private void OnEnable()
    {
        _move.Enable();
    }


    private void OnRoomSwitch(RoomSwitchEventInfo Eventinfo)
    {
        _playerManager.CanMove = false;
    }

    private void OnBlendingEnd(BlendingEndEventInfo Eventinfo)
    {
        _playerManager.CanMove = true;
    }
   
    public void OnMove(InputAction.CallbackContext context)
    {
        _change = context.ReadValue<Vector2>();             
    }

    private void FixedUpdate()
    {

        if (_playerManager.CurrentState ==  State.WALKING)
        {
            _playerManager.CurrentState = State.IDLE;
            _animator.SetBool("Walking", false);
        }
        if (_change != Vector3.zero)
        {
            if (_playerManager.CanMove)
            {
                _playerManager.CurrentState = State.WALKING;
                UpdateAnimation();
                MovePlayer();
            }
        }
    }

    private void UpdateAnimation()
    {
        _animator.SetBool("Walking", true);
        _animator.SetFloat("MoveX", _change.x);
        _animator.SetFloat("MoveY", _change.y);   
    }

    private void MovePlayer()
    {
        Vector2 newPosition = transform.position + _change * _speed * Time.fixedDeltaTime;
        _playerRigidbody.MovePosition(newPosition);
    }
}
