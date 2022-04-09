using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool CheckDoor()
    {
        if (this.gameObject.GetComponent<BoxCollider2D>().enabled == true)
            return true;
        else
            return false;
    }
    public void OpenDoor()
    {
        if (CheckDoor())
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Door");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
