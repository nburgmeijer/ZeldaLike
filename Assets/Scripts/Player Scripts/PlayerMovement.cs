using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private int speed;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;
    private bool canPlayerMove = true;

    #endregion
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RoomSwitchEvents.BlendingStartedEvent += OnBlendingStarted;
        RoomSwitchEvents.BlendingEndedEvent += OnBlendingStopped;
    }

    private void OnBlendingStarted(Object obj)
    {
        canPlayerMove = false;
    }

    private void OnBlendingStopped(Object obj)
    {
        canPlayerMove = true;
    }

    private void Update()
    {
        if(change != Vector3.zero)
        {
            change = Vector3.zero;
        }
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
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

    private void UpdateAnimation()
    {
        animator.SetBool("Walking", true);
        animator.SetFloat("MoveX", change.x);
        animator.SetFloat("MoveY", change.y);   
    }

    private void MovePlayer()
    {
        Vector2 newPosition = transform.position + change.normalized * speed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(newPosition);  
    }
}
