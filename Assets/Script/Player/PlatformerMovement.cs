using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    private float horizontalValue;
    private bool facingRight;
    [SerializeField] float walkSpeed, jumpPower;
    private Rigidbody2D rb;

    [Header("Air Jump(s)")]
    private int extraJumps;
    [SerializeField] private int jumpCounter;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    private PlayerAnimation anim;

    private BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<PlayerAnimation>();
    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        if (Grounded())
            isGrounded = true;
        else
            isGrounded = false;

        if (!PauseControl.gameIsPaused)
        {
            Move();
            Flip();
            IdleAnim();
        }

        if (isGrounded && jumpCounter==0)
        {
            jumpCounter = 1;
        }

        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            Jump();

    }
    void Flip()
    {
        if (horizontalValue < 0 && facingRight == true)
        {
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
        else if (horizontalValue > 0 && facingRight == false)
        {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        }
    }
    private bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 
            0, Vector2.down, 0.05f, groundLayer); 
        return raycastHit.collider != null;
    }
    void Jump()
    {
        if (jumpCounter == 1)
        {
            jumpCounter = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.Jump();
        }
        else 
            return;
    }
    void Move()
    {
        rb.velocity = new Vector2(horizontalValue * walkSpeed, rb.velocity.y);
        if (horizontalValue != 0 && isGrounded && rb.velocity.y > 0)
        {
            anim.Run();
        }
    }
    void IdleAnim()
    {
        if (horizontalValue == 0 && isGrounded && rb.velocity.y == 0)
        {
            anim.Idle();
        }
    }
}