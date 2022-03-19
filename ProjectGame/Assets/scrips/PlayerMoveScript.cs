using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] float speed = 3f; // скорость движения
    [SerializeField] int lives = 5; // скорость движения
    [SerializeField] float jumpForce = 15f; // сила прыжка

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;

    void Start()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sp.flipX = dir.x < 0.0f;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce; 
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer); // в ногах у перса круг маленького радиуса кот проверяет стоит ли он на земеле или нет
    }

}
