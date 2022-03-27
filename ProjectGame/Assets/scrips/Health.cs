using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    public int lives;
    public int maxlives;
    public bool isDead = false;



    public void Death()
    {
        Destroy(gameObject);
        gameController.LoseGame();
    }

    public bool DeathCheck(int lives)
    {
        if (lives <= 0)
        {
            return true;
        }
        return false;
    }

    public void TakeHit(int damage)
    {
        lives -= damage;
        isDead = DeathCheck(lives);
        if (isDead == true)
        {
            Death();
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



}
