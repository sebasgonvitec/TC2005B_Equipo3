using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //Gets path of level file from database
    public static string levelPath = @"C:\Users\sebas\Documents\4to Semestre\Construccion de Software\Videojuegos\saved_levels\second_test.bin";
    public string levelPathCopy = @"C:\Users\sebas\Documents\4to Semestre\Construccion de Software\Videojuegos\saved_levels\second_test.bin";

    //Gets time of level from database
    public static float levelTime = 120;
    public void Load()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
