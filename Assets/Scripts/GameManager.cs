using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Handles ending and starting matches
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;
    public static Action ResetState = delegate { };

    private void OnEnable() {
        TimeKeeper.TimeUp += EndMatch;
        MainMenu.GameSelected += StartMatch;
    }

    private void OnDisable() {
        TimeKeeper.TimeUp -= EndMatch;
        MainMenu.GameSelected -= StartMatch;
    }

    public void EndMatch()
    {
        //pauses background gameplay
        Time.timeScale = 0;
        endGameMenu.SetActive(true);
    }

    public void StartMatch()
    {
        //restarts background gameplay
        Time.timeScale = 1;
        ResetState.Invoke();
    }
}
