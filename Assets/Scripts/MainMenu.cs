using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Controller nonPlayerPaddle;
    public static Action GameSelected = delegate { };

    // Freeze background gameplay
    void Start()
    {
        Time.timeScale = 0;
    }

    public void PlaySinglePlayer()
    {
        gameObject.SetActive(false);
        //change nonplayer paddle to AI controller for single player (default is player controlled)
        nonPlayerPaddle.input = nonPlayerPaddle.GetComponent<AIInput>();
        GameSelected.Invoke();
    }

    public void PlayTwoPlayer()
    {
        gameObject.SetActive(false);
        GameSelected.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
