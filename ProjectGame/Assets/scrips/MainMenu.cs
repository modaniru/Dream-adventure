using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private FaderForMenu fader;
    [SerializeField] string SceneName;

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator LoadGame()
    {
        

        fader.gameObject.SetActive(true);

        yield return StartCoroutine(fader.Fade(true));

        SceneManager.LoadScene(SceneName);
    }
}
