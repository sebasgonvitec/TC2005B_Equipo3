/*
 Functions to manage the flow between Scenes based on their order on build settings

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    //Load Maker Scene
    public void LoadMaker()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    //Load Level Select Scene
    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3, LoadSceneMode.Single);        

    }

    public void LoadCredits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }

    public void CreditsBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
