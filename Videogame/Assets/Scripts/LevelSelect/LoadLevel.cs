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
        //OnLoad(LevelLoader.levelPath);
        OnLoadAlt(PlayerPrefs.GetString("levelString"));
    }

    //Function to load elements from .BIN file into the level
    public void OnLoad(string levelPath)
    {
        //Check how this works for saving levels in DB
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(
            levelPath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read);
        Debug.Log(stream);
        var obj = (Block[])formatter.Deserialize(stream);
        Debug.Log("obj");
        stream.Close();

        //Erase any elements in scene before starting to build it
        Clean();

        //Instantiate each prefab on level
        for (int i = 0; i < obj.Length; i++)
        {
            Instantiate(
                availableBlocks[obj[i].id],
                new Vector3(
                    obj[i].x,
                    obj[i].y,
                    obj[i].z), Quaternion.identity);
        }
    }

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
