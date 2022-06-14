/*
 Script to manage timer in Play Mode  

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

 23/05/2022
 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class CountdownPlay : MonoBehaviour
{
    //Set level time from Level info (from DB)
    private float timeStart;
    public Text textbox;
    public Text finalTimeText;

    public float initialTime;
    public float finalfinalTime; //arreglar variables feas
    public string finalTime;

    private bool timerStop;

    [SerializeField] private AudioSource nightmareSound;
    //Events for timer start and runOut
    public static event Action OnTimerRunOutPlay;
    public static event Action OnTimerStartPlay;

    public PostProcessVolume _postProcessVolume;
    private ColorGrading _colorGrading;
    private ChromaticAberration _chromaticAberration;


    private float saturation;
    private float intensity;

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
        textbox.enabled = true;
        initialTime = timeStart;
        OnTimerStartPlay?.Invoke();

        _postProcessVolume.profile.TryGetSettings(out _colorGrading);
        _postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
   
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

        if(timeStart <= 20)
        {
            if (!nightmareSound.isPlaying)
            {
                nightmareSound.Play();
            }
            
            saturation -= 4.5f * Time.deltaTime;
            _colorGrading.saturation.value = saturation;

            intensity += 0.05f * Time.deltaTime;
            _chromaticAberration.intensity.value = intensity;
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

    //Get int final time
    public int getFinalTimeInt()
    {
        return Mathf.FloorToInt(initialTime - timeStart);
    }
}
