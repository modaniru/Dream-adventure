using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Door door;
    private bool lever = false;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lever == true)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("LeverOff"); lever = false;
            }
            else
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("LeverOn"); lever = true;
            }
            door.SwitchDoor();
        }
    }
}


