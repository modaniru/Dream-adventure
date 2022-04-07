using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ladder : MonoBehaviour

{
    [SerializeField] float speed = 5f;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerJump.onLadder = true;
            coll.GetComponent<Rigidbody2D>().gravityScale = 0;
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
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerJump.onLadder = false;
            coll.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }
}
