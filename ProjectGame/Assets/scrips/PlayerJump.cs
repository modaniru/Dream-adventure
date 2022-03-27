using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerJump : MonoBehaviour
{
    float yInput;

    public bool onSlime = false;


    Rigidbody2D rb;
    SpriteRenderer sp;

    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        yInput = Input.GetAxis("Vertical");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
        if (onSlime)
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
