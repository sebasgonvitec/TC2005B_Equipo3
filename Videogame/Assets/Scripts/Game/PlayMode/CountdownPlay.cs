/*
 Script to manage timer in Play Mode  

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 23/05/2022
 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownPlay : MonoBehaviour
{
    //Set level time from Level info (from DB)
    private float timeStart;
    public Text textbox;
    public Text finalTimeText;

    public float initialTime;
    public float finalfinalTime;
    public string finalTime;

    private bool timerStop;

    //Events for timer start and runOut
    public static event Action OnTimerRunOutPlay;
    public static event Action OnTimerStartPlay;

    private void OnEnable()
    {
        LevelGoalPlay.GoalReachedPlay += StopTimer;
        OnTimerRunOutPlay += StopTimer;
    }

    private void OnDisable()
    {
        LevelGoalPlay.GoalReachedPlay -= StopTimer;
        OnTimerRunOutPlay -= StopTimer;
    }
    void Start()
    {
        timerStop = false;
        timeStart = PlayerPrefs.GetInt("levelTime");
        //timeStart = 337;
        textbox.enabled = true;
        initialTime = timeStart;
        OnTimerStartPlay?.Invoke();
    }
    
    void Update()
    {
        if (timerStop)
            return;

        if (timeStart <= 0.5f)
        {
            StopTimer();
            OnTimerRunOutPlay?.Invoke();
        }
        else 
        {
            //Substracts time passed to timeStart
            timeStart -= Time.deltaTime;
            //Format time to be displayed nicely
            int minutes = Mathf.FloorToInt(timeStart / 60F);
            int seconds = Mathf.FloorToInt(timeStart - minutes * 60);
            string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            finalTime = niceTime;

            //Update timer in UI
            textbox.text = niceTime;
        }
    }

    //Actually freeze timer
    public void StopTimer()
    {
        textbox.enabled = false;
        finalTimeText.text = finalTime;
        timerStop = true;
     }

    //Calculate the time elapsed and display it nicely
    public string getFinalTime()
    {
        finalfinalTime = initialTime - timeStart;
        int minutes = Mathf.FloorToInt(finalfinalTime / 60F);
        int seconds = Mathf.FloorToInt(finalfinalTime - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        finalTime = niceTime;

        return finalTime;
    }
}
