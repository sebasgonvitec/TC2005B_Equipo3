/*
 Script to pull information and build the level in the next scene

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public APITest apiTestScript;

    //Gets path of level file from database
    public static string levelPath = @"C:\Users\sebas\Documents\4to Semestre\Construccion de Software\Videojuegos\saved_levels\level_test.bin";
    public string levelPathCopy = @"C:\Users\sebas\Documents\4to Semestre\Construccion de Software\Videojuegos\saved_levels\third_test2.bin";

    //Get string from DB
    public string levelString;

    //Gets time of level from database
    public static float levelTime = 120;

    //Load scene with all its elements
    public void Load()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
}
