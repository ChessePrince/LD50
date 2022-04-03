using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    private float horizontalValue;
    [SerializeField] private bool facingRight;
    [SerializeField] float walkSpeed, jumpPower;
    private Rigidbody2D rb;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Transform m_GroundCheck;
    //private bool isGrounded;

    private BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        Move();
        Flip();
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            Jump();
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);

        //help me
        if (Grounded())
        {
            coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
            jumpCounter = extraJumps; //Reset jump counter to extra jump value
        }
        else 
        { 
            coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
        }
    }

    void Flip()
    {
        //input is moving the player right and the player is facing left
        if (horizontalValue > 0 && !facingRight)
        {
            ActualFlip();
        }
        //input is moving the player left and the player is facing right
        else if (horizontalValue < 0 && facingRight)
        {
            ActualFlip();
        }
    }
    private bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    void ActualFlip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Jump()
    {
        if (coyoteCounter <= 0 && jumpCounter <= 0) return;
        if (Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        else
        {
            //If not on the ground and coyote counter bigger than 0 do a normal jump
            if (coyoteCounter > 0)
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            else
            {
                if (jumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                    jumpCounter--;
                }
            }
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(horizontalValue * walkSpeed, rb.velocity.y);
    }
}
