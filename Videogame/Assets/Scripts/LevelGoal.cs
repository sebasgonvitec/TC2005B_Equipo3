//Reaching goal

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] Text endMessage;

    public static event Action GoalReached;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            endMessage.text = "GOAL REACHED!!";
            GoalReached?.Invoke();
            //Invoke("ChangeScene", 1);
        }


    }

    //void ChangeScene()
    //{
    //    SceneManager.LoadScene("WinScene");
    //}
}