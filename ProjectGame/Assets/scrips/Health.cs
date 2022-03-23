using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int lives;
    public int maxlives;
    string SceneName;

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneName);
    }

    public void TakeHit(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Destroy(gameObject);
            RestartLevel();
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

    public void Awake()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes
}
