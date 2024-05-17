using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Controller nonPlayerPaddle;
    [SerializeField] Toggle toggle;
    public static Action GameSelected = delegate { };
    public static Action<bool> ToggleClicked = delegate { };
    GameObject[] toggleableObjects;

    void Start()
    {
        // Freeze background gameplay
        Time.timeScale = 0;
        //Cache modded objects for enabling/disabling
        toggleableObjects = GameObject.FindGameObjectsWithTag("Mod");
        //Initially disable them
        ToggleMods();
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

    public void ToggleMods()
    {
        //Event to tell controller that it shouldn't be using any modded actions
        ToggleClicked.Invoke(toggle.isOn);
        //Change active status on cached modded objects
        foreach (GameObject obj in toggleableObjects)
        {
            obj.SetActive(toggle.isOn);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
