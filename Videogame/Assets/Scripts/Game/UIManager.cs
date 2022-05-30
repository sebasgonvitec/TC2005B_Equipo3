//Managing Menus (currently game over menu only)

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        //CountdownPlay.OnTimerStartPlay += DisableGameOverMenu;
        CountdownPlay.OnTimerRunOutPlay += EnableGameOverMenu;
     
    }

    private void OnDisable()
    {
        LevelGoalPlay.GoalReachedPlay -= EnableLevelPassedMenu;
        LevelGoalPlay.GoalReachedPlay -= SetFinalTime;
        //CountdownPlay.OnTimerStartPlay -= DisableGameOverMenu;
        CountdownPlay.OnTimerRunOutPlay -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    //public void DisableGameOverMenu()
    //{
    //    gameOverMenu.SetActive(false);
    //}

    public void EnableLevelPassedMenu()
    {
        levelPassedMenu.SetActive(true);
    }

    public void SetFinalTime()
    {
        finalTime.text = "Time: " + countdownScript.getFinalTime();
    }

   
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
