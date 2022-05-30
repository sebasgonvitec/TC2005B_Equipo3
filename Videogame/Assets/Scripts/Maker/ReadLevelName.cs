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
        Debug.Log(levelName);
    }

    public string GetLevelName()
    {
        return levelName;
    }
}
