/*
 Script to read name of level from input field

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadLevelName : MonoBehaviour
{
    public string levelName;

    public void ReadStringInput(string s) 
    {
        levelName = s;
        //Debug.Log(levelName);
    }

    public string GetLevelName()
    {
        return levelName;
    }
}
