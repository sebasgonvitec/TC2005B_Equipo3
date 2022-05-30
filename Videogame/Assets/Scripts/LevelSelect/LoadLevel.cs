using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]

public class LoadLevel : MonoBehaviour
{

    public GameObject[] availableBlocks;

    MakerBlock[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        //OnLoad(LevelLoader.levelPath);
    }

    public void OnLoad(string levelPath)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(
            levelPath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read);
        var obj = (Block[])formatter.Deserialize(stream);
        stream.Close();

        Clean();

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
