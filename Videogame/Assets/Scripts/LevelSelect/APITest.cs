using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Level
{
    public int id_level;
    public int id_user;
    public string level_name;
    public string level_file;
    public int level_time;
    public int num_items;
}

public class NewLevel
{
    public int id_user;
    public string level_name;
    public string level_file;
    public int level_time;
    public int num_items;
}

[System.Serializable]
public class LevelsList
{
    public List<Level> levels;
}
public class APITest : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getLevelsEP;

    public GameObject itemPrefab;
    public Transform contentPanel;

    public LevelsList allLevels;
    public LevelsList allLevelsFiles;

    public string levelString;
    public int levelTime;

    void Start()
    {
        //Debug.Log("Started Query");
        QueryLevels();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    LoadLevels();
        //}
    }

    public void QueryLevels()
    {
        StartCoroutine(GetLevels());
    }

    IEnumerator GetLevels()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getLevelsEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{\"levels\":" + www.downloadHandler.text + "}";
                allLevels = JsonUtility.FromJson<LevelsList>(jsonString);
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        LoadLevels();
    }

    public void LoadLevels()
    {
        Clear();
        //Debug.Log("Load Levels Started");
        for (int i = 0; i < allLevels.levels.Count; i++)
        {
            Level lvl = allLevels.levels[i];

            var item = Instantiate(itemPrefab, contentPanel);
            Text[] textFields = item.GetComponentsInChildren<Text>();
            textFields[0].text = lvl.level_name;
            textFields[1].text = lvl.id_user.ToString();
            textFields[2].text = lvl.level_time.ToString();
            textFields[3].text = lvl.num_items.ToString();

            //Debug.Log(lvl.level_file);
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                QueryLevelFiles(lvl.id_level);
            });
        }
    }

    void Clear()
    {
        foreach(Button child in contentPanel.GetComponentsInChildren<Button>())
        {
            Destroy(child.gameObject);
        }
    }

    
    //Functions to obtain level file by level id
    public void QueryLevelFiles(int levelId)
    {
        StartCoroutine(GetLevelFiles(levelId));
    }
    IEnumerator GetLevelFiles(int levelId)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getLevelsEP + "/" +levelId))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{\"levels\":" + www.downloadHandler.text + "}";
                allLevelsFiles = JsonUtility.FromJson<LevelsList>(jsonString);
                Level lvl = allLevelsFiles.levels[0];

                levelString = lvl.level_file;
                levelTime = lvl.level_time;

                PlayerPrefs.SetString("levelString", levelString);
                PlayerPrefs.SetInt("levelTime", levelTime);

                //Debug.Log(PlayerPrefs.GetString("levelString"));
                //Debug.Log(PlayerPrefs.GetInt("levelTime"));

            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        Load();
    }

    public void Load()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
}
