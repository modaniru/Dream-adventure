using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Fader fader;
    public bool AfterMenu;
    string SceneName;




    void Start()
    {
        StartGame();
    }

    public void Awake()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }



    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void StartGame()
    {
        StartCoroutine(StartRoutine());
    }

    public void LoseGame()
    {
        StartCoroutine(LoseRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return StartCoroutine(fader.Fade(false));

        fader.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    private IEnumerator LoseRoutine()
    {
        Time.timeScale = 0.4f; // замедляет время

        fader.gameObject.SetActive(true);

        yield return StartCoroutine(fader.Fade(true));

        StartCoroutine(fader.StartBlinkRetryButton());
    }

}
