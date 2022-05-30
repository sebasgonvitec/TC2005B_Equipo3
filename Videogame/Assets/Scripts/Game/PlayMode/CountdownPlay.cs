using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownPlay : MonoBehaviour
{
    private float timeStart = LevelLoader.levelTime;
    public Text textbox;
    public Text finalTimeText;

    public float initialTime;
    public float finalfinalTime;
    public string finalTime;

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
        textbox.enabled = true;
        initialTime = timeStart;
        OnTimerStartPlay?.Invoke();
        //textbox.text = timeStart.ToString();
        //Se obtiene el tiempo de la base de datos y se inserta aqui
        //timeStart = ReadTimer.input;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart <= 0.5f)
        {
            StopTimer();
            OnTimerRunOutPlay?.Invoke();
            
           
        }
        else
        {
            timeStart -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeStart / 60F);
            int seconds = Mathf.FloorToInt(timeStart - minutes * 60);
            string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            finalTime = niceTime;

            textbox.text = niceTime;
        }
    }

    public void StopTimer()
    {
        textbox.enabled = false;
        finalTimeText.text = finalTime;
    }

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
