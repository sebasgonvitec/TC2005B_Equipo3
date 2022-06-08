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
    public int times_played;
    public string date_created;
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


[System.Serializable]
public class LevelView
{
    public string username;
    public int id_level;
    public string level_name;
    public string level_file;
    public string date_created;
}

[System.Serializable]
public class LevelViewList
{
    public List<LevelView> levelViews;
}


public class APITest : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getLevelsEP;
    [SerializeField] string getLevelViewEP;
    [SerializeField] string getSPTimesPlayedEP;

    public GameObject itemPrefab;
    public Transform contentPanel;

    public LevelsList allLevels;
    public LevelsList allLevelsFiles;

    public LevelViewList allLevelView;
    public LevelView levelView;

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
                StartCoroutine(GetLevelView());
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        
    }

    //Get username of a certain level_id from levels view 
    IEnumerator GetLevelView()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getLevelViewEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{\"levelViews\":" + www.downloadHandler.text + "}";
                allLevelView = JsonUtility.FromJson<LevelViewList>(jsonString);   
                LoadLevels();
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        
    }

    
    //Function that loads all level buttons in the select page
    public void LoadLevels()
    {
        Clear();
        //Debug.Log("Load Levels Started");
        for (int i = 0; i < allLevels.levels.Count; i++)
        {
            Level lvl = allLevels.levels[i]; // access current level
            LevelView levelView = allLevelView.levelViews[i]; // access current view

            //StartCoroutine(GetUsername(lvl.id_level));
            // Level lvl = allLevels.levels[i]; // access current level

            var item = Instantiate(itemPrefab, contentPanel);
            Text[] textFields = item.GetComponentsInChildren<Text>();
            textFields[0].text = levelView.level_name;
            textFields[1].text = levelView.username;
            textFields[2].text = lvl.times_played.ToString();
            textFields[3].text = levelView.date_created;

            
            //Debug.Log(lvl.level_file);
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("id_level", lvl.id_level); //save the current level id 
                QueryLevelFiles(lvl.id_level);
                CallTimesPlayedSP(lvl.id_level); // call SP to increase num of times played  
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


    //Function that starts coroutine to call times_played stored procedure
    public void CallTimesPlayedSP(int levelId)
    {
        StartCoroutine(UpdateTimesPlayed(levelId));
    }

    //Calls stored procedure to increase de number of times played of a level
    IEnumerator UpdateTimesPlayed(int levelId)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getSPTimesPlayedEP + levelId))
        {
            yield return www.SendWebRequest();
        }
        
    }
}
