/*
 Timer Script for Test Mode in Maker

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 15/05/2022
 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    //Set level time from Level info (from Maker UI)
    private float timeStart = 0f;
    public Text textbox;
    public Text finalTimeText;
    private string finalTime;
    
    public static event Action OnTimerRunOut;

    private void OnEnable()
    {
        LevelGoal.GoalReached += StopTimer;
    }

    private void OnDisable()
    {
        LevelGoal.GoalReached -= StopTimer;
    }
    void Start()
    {
        textbox.enabled = true;
        textbox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (MakerMode.playMode)
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

            if (timeStart <= 0)
            {
                OnTimerRunOut?.Invoke();
            }
        }
        else 
        {   
            timeStart = ReadTimer.input;
        }

    }

    //Actually freeze timer
    public void StopTimer()
    {
        textbox.enabled = false;
        finalTimeText.text = finalTime;
    }

}