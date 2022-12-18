using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverMenu;
    public AudioSource myAudio;

    public void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        myAudio.Stop();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
