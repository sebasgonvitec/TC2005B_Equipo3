
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveBinary : MonoBehaviour
{

    //Blocks available to save level
    public GameObject[] availableBlocks;

    //Level name from input field
    public GameObject readLevelName;
    private string levelName;
    private string path;

    //Save contents to a string variables
    private string blocksString;
    Block[] serializeBlocksString;

    MakerBlock[] blocks;
    Block[] serializeBlocks;

    [SerializeField] string url;
    [SerializeField] string newLevelEP;

    public void OnSave()
    {
        levelName = readLevelName.GetComponent<ReadLevelName>().GetLevelName();
        //This path will instead be the file to upload to the DB
        path = $@"C:\Users\sebas\Documents\4to Semestre\Construccion de Software\Videojuegos\saved_levels\{levelName}.bin";

        blocks = GameObject.FindObjectsOfType<MakerBlock>();
        serializeBlocks = new Block[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            serializeBlocks[i] = new Block(
                blocks[i].transform.position.x,
                blocks[i].transform.position.y,
                blocks[i].transform.position.z,
                blocks[i].id);
        }
        //Total number of blocks used in level
        print(blocks.Length);

        //Serialize (or something) the file
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None);

        formatter.Serialize(stream, serializeBlocks);
        stream.Close();
    }

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

    void Clean()
    {
        blocks = GameObject.FindObjectsOfType<MakerBlock>();
        foreach (var i in blocks)
        {
            Destroy(i.gameObject);
        }
    }
}
