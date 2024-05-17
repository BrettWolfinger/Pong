using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Controller nonPlayerPaddle;
    [SerializeField] Controller player1;
    [SerializeField] GameManager gameManager;

    // Freeze background gameplay
    void Start()
    {
        Time.timeScale = 0;
    }

    public void PlaySinglePlayer()
    {
        gameObject.SetActive(false);
        nonPlayerPaddle.input = nonPlayerPaddle.GetComponent<AIInput>();
        gameManager.StartMatch();
    }

    public void PlayTwoPlayer()
    {
        gameObject.SetActive(false);
        gameManager.StartMatch();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
