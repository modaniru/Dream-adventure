using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float speed = 3f;

    private int currentIndex;
    private Vector2 currentPoint;
    private bool walking;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = points[0].position;
        ChooseDirection();
        walking = true;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if (walking)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, currentPoint, step);

            if (Vector3.Distance(transform.position,currentPoint) < 0.3f)
            {
                StartCoroutine(Idle());
            }
        }
    }

    private IEnumerator Idle() // IEnumerator - процесс работающий паралельно других процессов
    {
        walking = false;
        ChooseNextPoint();

        yield return new WaitForSeconds(0.5f);

        walking = true;
    }

    private void ChooseNextPoint()
    {
        if (currentIndex + 1 < points.Count)
        {
            currentIndex = currentIndex + 1;
        }
        else
        {
            currentIndex = 0;
        }
        currentPoint = points[currentIndex].position;
        ChooseDirection();
    }

    private void ChooseDirection()
    {
        GetComponent<SpriteRenderer>().flipX = currentPoint.x < transform.position.x;
    }

}
