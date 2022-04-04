using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Interactable
{
    bool isPressed = false;

    public void Interact()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isPressed = true;
        }
        else 
            isPressed = false;
    }

    public bool Check()
    {
        if (isPressed)
            return true;
        return false;
    }
}
