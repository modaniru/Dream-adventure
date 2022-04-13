using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool CheckDoor()
    {
        if (this.gameObject.GetComponent<BoxCollider2D>().enabled == true)
            return true;
        else
            return false;
    }
    public void SwitchDoor()
    {
        if (CheckDoor())
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("DoorOpen");
        } else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<Animator>().SetTrigger("DoorClose");
        }
    }
}
