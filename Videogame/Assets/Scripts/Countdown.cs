//Timer for the level

// Sebasti�n Gonz�lez Villacorta
// A01029746
// Karla Valeria Mondrag�n Rosas
// A01025108

// 13/05/2022

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] float timeStart;
    public Text textbox;
    public Text finalTimeText;
    public string finalTime;

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
        timeStart -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeStart / 60F);
        int seconds = Mathf.FloorToInt(timeStart - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        finalTime = niceTime;

        textbox.text = niceTime;

        if (timeStart <= 0)
        {
            OnTimerRunOut?.Invoke();
        }   
    }

    public void StopTimer()
    {
        textbox.enabled = false;
        finalTimeText.text = finalTime;
    }
}
