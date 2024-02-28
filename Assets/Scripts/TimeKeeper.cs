using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour, IResetable
{
    [SerializeField] float matchTime = 60f;
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] GameManager gameManager;
    bool isTimeUp = false;
    float time;

    void Start()
    {
        time = matchTime;
    }

    //Counts down time until time is up and then ends the match
    void Update()
    {
        if(!isTimeUp)
        {
            time -= Time.deltaTime;
            timerUI.text = ((int)time).ToString();
            if(time < 0)
            {
                isTimeUp = true;
                gameManager.EndMatch();
            }
        }
    }

    public void Reset()
    {
        isTimeUp = false;
        time = matchTime;
    }
}
