/*
 Functions to manage the flow between Scenes based on their order on build settings

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //Load Level Select Scene
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    //Load LogSign Scene
    public void LoadLogSign()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    //Load Login Scene
    public void LoadLogin()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    //Load SignIn Scene
    public void LoadSignIn()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}
