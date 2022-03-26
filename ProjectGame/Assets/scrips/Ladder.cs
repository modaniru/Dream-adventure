using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void OnTriggerStay2D(Collider2D coll)
    {
        coll.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (coll.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        coll.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

}
