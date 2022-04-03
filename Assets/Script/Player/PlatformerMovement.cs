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
        //CheckForGround();
        Move();
        Flip();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
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
    void CheckForGround()
    {
        //isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.y, gameObject.transform.position.y - 0.9f), new Vector2(0.6f, 0.2f), 0f, groundLayer);
    }
    bool Grounded()
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
        if (Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //isGrounded = false;
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(horizontalValue * walkSpeed, rb.velocity.y);
    }
}
