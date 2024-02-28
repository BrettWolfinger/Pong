using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

//Handles ending and starting matches
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;
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
        //finds all the objects that extend resetable and resets state for 
        //start of next game
        var ss = FindObjectsOfType<MonoBehaviour>().OfType<IResetable>();
        foreach(IResetable s in ss) {
            s.Reset();
        }
    }
}
