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

    // Freeze background gameplay
    void Start()
    {
        Time.timeScale = 0;
        toggleableObjects = GameObject.FindGameObjectsWithTag("Mod");
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
        ToggleClicked.Invoke(toggle.isOn);
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
