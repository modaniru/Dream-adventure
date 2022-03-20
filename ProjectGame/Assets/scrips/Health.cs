using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int lives;
    public int maxlives;

    public void TakeHit(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int bonusHealth)
    {
        lives += bonusHealth;

        if (lives > maxlives)
        {
            lives = maxlives;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
