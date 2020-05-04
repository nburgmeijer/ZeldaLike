using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private int speed;
    [SerializeField] private InputActionAsset playerControls;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;
    private bool canPlayerMove = true;
    private InputAction move;
    
    #endregion
    void Awake()
    {
        move = playerControls.FindAction("Move");
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        EventManager<RoomSwitchEventInfo>.RegisterListener(OnRoomSwitch);
        EventManager<BlendingEndEventInfo>.RegisterListener(OnBlendingEnd);
        move.performed += OnMove;
        move.canceled += OnMove;
    }
    private void OnEnable()
    {
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    private void OnRoomSwitch(RoomSwitchEventInfo Eventinfo)
    {
        canPlayerMove = false;
    }

    private void OnBlendingEnd(BlendingEndEventInfo Eventinfo)
    {
        canPlayerMove = true;
    }
   
    public void OnMove(InputAction.CallbackContext context)
    {
        change = context.ReadValue<Vector2>();             
    }

    private void FixedUpdate()
    {

        if (animator.GetBool("Walking"))
        {
            animator.SetBool("Walking", false);
        }
        if (change != Vector3.zero)
        {
            if (canPlayerMove)
            {
                UpdateAnimation();
                MovePlayer();
            }
        }
    }

    private void Update()
    {

    }

    private void UpdateAnimation()
    {
        animator.SetBool("Walking", true);
        animator.SetFloat("MoveX", change.x);
        animator.SetFloat("MoveY", change.y);   
    }

    private void MovePlayer()
    {
        Vector2 newPosition = transform.position + change * speed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(newPosition);
    }
}
