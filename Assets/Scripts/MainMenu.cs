using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] PaddleController nonPlayerPaddle;
    [SerializeField] GameManager gameManager;

    // Freeze background gameplay
    void Start()
    {
        Time.timeScale = 0;
    }

    public void PlaySinglePlayer()
    {
        gameObject.SetActive(false);
        nonPlayerPaddle.SetAI(true);
        gameManager.StartMatch();
    }

    public void PlayTwoPlayer()
    {
        gameObject.SetActive(false);
        nonPlayerPaddle.SetAI(false);
        gameManager.StartMatch();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
