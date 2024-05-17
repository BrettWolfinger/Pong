using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] float matchTime = 60f;
    [SerializeField] TextMeshProUGUI timerUI;
    public static Action TimeUp = delegate { }; //event triggered when time runs out
    bool isTimeUp = false;
    float time;

    void Start()
    {
        time = matchTime;
    }
    private void OnEnable() {
        GameManager.ResetState += Reset;
    }

    private void OnDisable() {
        GameManager.ResetState -= Reset;
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
                TimeUp.Invoke();
            }
        }
    }

    private void Reset()
    {
        isTimeUp = false;
        time = matchTime;
    }
}
