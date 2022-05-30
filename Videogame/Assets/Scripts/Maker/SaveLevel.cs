using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
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

    public GameObject[] availableBlocks;
    public GameObject readLevelName;
    private string levelName;
    private string path;
    
    MakerBlock[] blocks;
    Block[] serializeBlocks;
    
    public void OnSave()
    {
        levelName = readLevelName.GetComponent<ReadLevelName>().GetLevelName();
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
        print(blocks.Length);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None);

        formatter.Serialize(stream, serializeBlocks);
        stream.Close();

        Debug.Log("Saved in: "+ path);

    }

    //public void OnLoad()
    //{
    //    IFormatter formatter = new BinaryFormatter();
    //    Stream stream = new FileStream(
    //        path,
    //        FileMode.Open,
    //        FileAccess.Read,
    //        FileShare.Read);
    //    var obj = (Block[])formatter.Deserialize(stream);
    //    stream.Close();

    //    Clean();

    //    for (int i = 0; i < obj.Length; i++)
    //    {
    //        Instantiate(
    //            availableBlocks[obj[i].id],
    //            new Vector3(
    //                obj[i].x,
    //                obj[i].y,
    //                obj[i].z), Quaternion.identity);
    //    }
    //}

    //void Clean()
    //{
    //    blocks = GameObject.FindObjectsOfType<MakerBlock>();
    //    foreach (var i in blocks)
    //    {
    //        Destroy(i.gameObject);
    //    }
    //}
}
