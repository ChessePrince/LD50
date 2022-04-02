using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    float horizontalValue;
    float verticalValue;
    [SerializeField] private bool facingRight;
    public float walkSpeed, jumpSpeed;
    Rigidbody2D rb;
    float moveInput;

    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
    void Update()
    {
        CheckForGround();
        Move();
        CheckAxes();
        Flip();
        Jump();
    }
    void CheckAxes()
    {
        horizontalValue = Input.GetAxis("Horizontal") * walkSpeed;
        //verticalValue = 0f;
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
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.y, gameObject.transform.position.y - 0.9f), new Vector2(0.6f, 0.2f), 0f, m_WhatIsGround);
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
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isGrounded = false;
        }
    }
    void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
    }
}
