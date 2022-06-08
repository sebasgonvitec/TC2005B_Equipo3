/*
 Scprit to manage Play Mode UI (Game over, Game passed)

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

 26/05/2022
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject levelPassedMenu;
    [SerializeField] Text finalTime;

    [SerializeField] CountdownPlay countdownScript;

   
    
    private void OnEnable()
    {

        LevelGoalPlay.GoalReachedPlay += EnableLevelPassedMenu;
        LevelGoalPlay.GoalReachedPlay += SetFinalTime;
        CountdownPlay.OnTimerRunOutPlay += EnableGameOverMenu;
     
    }

    private void OnDisable()
    {
        LevelGoalPlay.GoalReachedPlay -= EnableLevelPassedMenu;
        LevelGoalPlay.GoalReachedPlay -= SetFinalTime;
        CountdownPlay.OnTimerRunOutPlay -= EnableGameOverMenu;
    }

    //Set Game Over Menu state to active
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        //StartCoroutine(CreateGameplay());
    }

    //Set Level Passed menu state to active
    public void EnableLevelPassedMenu()
    {
        levelPassedMenu.SetActive(true);
        //StartCoroutine(CreateGameplay());
    }

    //Set final time in Level ppp
    public void SetFinalTime()
    {
        finalTime.text = "Time: " + countdownScript.getFinalTime();
    }

    //Reload whole scene to restart the level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

