/*
 Script to Read File of level and Instantiate the block into the scene

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]

public class LoadLevel : MonoBehaviour
{
    //Array of blocks available to build the level
    public GameObject[] availableBlocks;

    MakerBlock[] blocks;
    
    //Load level on Start
    void Start()
    {
        OnLoadAlt(PlayerPrefs.GetString("levelString"));
    }

    //Function to load elements from string into the level
    public void OnLoadAlt(string levelString)
    {
        string[] blocks = levelString.Split('<');

        for (int i = 0; i < blocks.Length - 1; i++)
        {
            string[] finalblock = blocks[i].Split(',');
            Instantiate(
                availableBlocks[int.Parse(finalblock[0])],
                new Vector3(
                    float.Parse(finalblock[1]),
                    float.Parse(finalblock[2]),
                    float.Parse(finalblock[3])), Quaternion.identity);
        }
    }

    //Destroys all game objects in the scene
    void Clean()
    {
        blocks = GameObject.FindObjectsOfType<MakerBlock>();
        foreach (var i in blocks)
        {
            Destroy(i.gameObject);
        }
    }

}
