using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] float speed = 3f; // скорость движения

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    [Header("Player Animation Settings")]
    public Animator animator;

    void Start()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        float HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        if (Input.GetButton("Horizontal"))
            Run();
    }

    void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sp.flipX = dir.x < 0.0f;
    }

    public void SetSpeed(float bonusSpeed)
    {
        speed += bonusSpeed;
    }

    public void ReduceSpeed(float bonusSpeed)
    {
        speed -= bonusSpeed;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = coll.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }

}
