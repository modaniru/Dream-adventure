using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    [SerializeField] float slowSpeed = 2f;
    private static bool onSlime = false;
    private static bool check = true;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (onSlime)
        {
            check = false;
        }
        if (coll.gameObject.CompareTag("Player") && !onSlime)
        {
            onSlime = true;
            PlayerMoveScript player = coll.gameObject.GetComponent<PlayerMoveScript>();
            player.ReduceSpeed(slowSpeed);
            PlayerJump jumpForce = coll.gameObject.GetComponent<PlayerJump>();
            jumpForce.onSlime = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && check)
        {
            onSlime = false;
            PlayerMoveScript player = coll.gameObject.GetComponent<PlayerMoveScript>();
            player.SetSpeed(slowSpeed);
            PlayerJump jumpForce = coll.gameObject.GetComponent<PlayerJump>();
            jumpForce.onSlime = false;
        }
        check = true;

    }

}
