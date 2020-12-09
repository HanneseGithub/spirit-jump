using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        StartCoroutine(AudioSourceFade.StartFade(audioSource, 3, (float)0.4));
    }

    public void ShowMenu()
    {
        // Load the game scene
        SceneManager.LoadScene(0);
    }

    public void StartNewGame()
    {
        //StartCoroutine(AudioSourceFade.StartFade(audioSource, 3, 0));
        // Delete the score every time new game starts
        PlayerPrefs.DeleteKey("Score");

        // Load the game scene
        SceneManager.LoadScene(1);
    }

    public void ShowOptions()
    {
        // Load the game scene
        SceneManager.LoadScene(3);
    }

    public void ShowShop()
    {
        // Load the game scene
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
