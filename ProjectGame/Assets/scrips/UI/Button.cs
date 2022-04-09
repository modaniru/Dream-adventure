using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private Door door;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Button");
            door.OpenDoor();
        }
    }
}
