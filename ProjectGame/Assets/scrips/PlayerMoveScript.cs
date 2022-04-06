using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] float speed = 3f; // скорость движения

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public int money = 0;

    private float originalSpeed;

    private Interactable interactableObj;

    [Header("Player Animation Settings")]
    public Animator animator;

    void Start()
    {
        originalSpeed = speed;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        float HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        if (Input.GetButton("Horizontal"))
            Run();

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObj();
        }
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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Interactable"))
        {
            interactableObj = coll.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Interactable"))
        {
            interactableObj = null;
        }
    }

    private void InteractWithObj()
    {
        if (interactableObj != null)
        {
            interactableObj.Interact();
        }
    }

    public void AddCoin(int value)
    {
        money += value;
    }

    public bool CheckCoin(int money)
    {
        if (money >= 3)
        {
            return true;
        }
        return false;
    }

}
