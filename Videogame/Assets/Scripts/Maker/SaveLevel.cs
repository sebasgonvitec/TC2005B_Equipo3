/*
 Script to Upload levels to DB

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]

//Creation of Block model to store level buidling blocks
public struct Block
{
    public float x, y, z;
    public int id;

    public Block(float x, float y, float z, int id)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}
public class SaveLevel : MonoBehaviour
{
    //Blocks available to save level
    public GameObject[] availableBlocks;

    //Level name from input field
    public GameObject readLevelName;
    private string levelName;

    //Save contents to a string variables
    private string blocksString;
    Block[] serializeBlocksString;

    MakerBlock[] blocks;

    [SerializeField] string url;
    [SerializeField] string newLevelEP;

    //Function to be executed when save button is pressed
    public void OnSaveAlt()
    {
        levelName = readLevelName.GetComponent<ReadLevelName>().GetLevelName();

        if (levelName == "" || ReadTimer.inputInt == 0)
        {
            Debug.Log("Missing Level Name or Time");
        }
        else
        {
            blocks = GameObject.FindObjectsOfType<MakerBlock>();
            serializeBlocksString = new Block[blocks.Length];
            for (int i = 0; i < blocks.Length; i++)
            {
                serializeBlocksString[i] = new Block(
                    blocks[i].transform.position.x,
                    blocks[i].transform.position.y,
                    blocks[i].transform.position.z,
                    blocks[i].id);
            }

            for (int j = 0; j < serializeBlocksString.Length; j++)
            {
                blocksString += serializeBlocksString[j].id.ToString() + "," + serializeBlocksString[j].x.ToString() + "," + serializeBlocksString[j].y.ToString() + "," + serializeBlocksString[j].z.ToString() + "<";
            }

            InsertNewLevel();
        }
    }

    public void InsertNewLevel()
    {
        StartCoroutine(AddLevel());
    }

    IEnumerator AddLevel()
    {
        // Create the object to be sent as json
        NewLevel newLevel = new NewLevel
        {
            id_user = PlayerPrefs.GetInt("id_user"),
            level_name = levelName,
            level_file = blocksString,
            level_time = ReadTimer.inputInt,
            num_items = blocks.Length
        };

        string jsonData = JsonUtility.ToJson(newLevel);
        //Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + newLevelEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }
}
