using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    [SerializeField] float slowSpeed = 2f;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerMoveScript player = coll.gameObject.GetComponent<PlayerMoveScript>();
            player.ReduceSpeed(slowSpeed);
            PlayerJump jumpForce = coll.gameObject.GetComponent<PlayerJump>();
            jumpForce.onSlime = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerMoveScript player = coll.gameObject.GetComponent<PlayerMoveScript>();
            player.SetSpeed(slowSpeed);
            PlayerJump jumpForce = coll.gameObject.GetComponent<PlayerJump>();
            jumpForce.onSlime = false;
        }
    }

}
