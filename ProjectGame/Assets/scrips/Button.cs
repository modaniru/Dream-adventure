using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private Door door;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Box"))
        {
                this.gameObject.GetComponent<Animator>().SetTrigger("ButtonDown");
                door.SwitchDoor();
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Box"))
        {
                this.gameObject.GetComponent<Animator>().SetTrigger("ButtonUp");
                door.SwitchDoor();
        }
    }

}
