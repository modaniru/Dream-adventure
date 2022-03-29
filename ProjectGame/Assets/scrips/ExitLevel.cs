using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            int coins = coll.gameObject.GetComponent<PlayerMoveScript>().money;
            if (coll.gameObject.GetComponent<PlayerMoveScript>().CheckCoin(coins))
            {
                ChangeScene();
            }
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }

  

    
}
