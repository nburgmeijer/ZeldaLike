using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        animator.SetBool("Walking", false);
        if (change != Vector3.zero)
        {
            UpdateAnimation();
            MovePlayer();
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
