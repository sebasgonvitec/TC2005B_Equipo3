using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameplayCreate : MonoBehaviour
{
    [SerializeField] CountdownPlay countdownScript;

    //API / DB elements
    [SerializeField] string url; // root 
    [SerializeField] string getGameplayEP; //get gameplay endpoint


    // GAMEPLAY Table Structure
    [System.Serializable]
    public class Gameplay
    {
        // public int id_gameplay;
        public int id_user;
        public int id_level;
        public int time_elapsed;
        // public string date_played;
    }

    [System.Serializable]
    public class GameplayList
    {
        public List<Gameplay> users;
    }


    private void OnEnable()
    {

        LevelGoalPlay.GoalReachedPlay += StartGameplayCreate;
        CountdownPlay.OnTimerRunOutPlay += StartGameplayCreate;
     
    }


    private void OnDisable()
    {
        LevelGoalPlay.GoalReachedPlay -= StartGameplayCreate;
        CountdownPlay.OnTimerRunOutPlay -= StartGameplayCreate;
    }


    public void StartGameplayCreate()
    {
        StartCoroutine(CreateGameplay());
    }


    IEnumerator CreateGameplay()
    {
        // Create the object to be sent as json
        Gameplay newGameplay = new Gameplay();
        newGameplay.id_user = PlayerPrefs.GetInt("id_user");
        newGameplay.id_level = PlayerPrefs.GetInt("id_level");
        newGameplay.time_elapsed = countdownScript.getFinalTimeInt();
        
        //Convert C# object to json
        string jsonData = JsonUtility.ToJson(newGameplay);

        Debug.Log("BODY: " + jsonData);

        // Send using the Put method
        using (UnityWebRequest www = UnityWebRequest.Put(url + getGameplayEP, jsonData))
        {
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            //Evaluate web request had code 200 ok
            if (www.result == UnityWebRequest.Result.Success) 
            {
                Debug.Log("Response: " + www.downloadHandler.text);
            } 
            else 
                Debug.Log("Error: " + www.error); 
        }
    }

}
