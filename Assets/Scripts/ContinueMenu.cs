using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinueMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI scoreLeft;
    [SerializeField] private TextMeshProUGUI scoreRight;

    //Figure out and display who won the game at match end
    void OnEnable()
    {
        if(Int32.Parse(scoreLeft.text) < Int32.Parse(scoreRight.text))
        {
            winnerText.text = "Right player wins!";
        }
        else if (Int32.Parse(scoreLeft.text) > Int32.Parse(scoreRight.text))
        {
            winnerText.text = "Left player wins!";
        }
        else
        {
            winnerText.text = "Tie!";
        }
    }
    
    //continue button back to main menu
    public void Continue()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
