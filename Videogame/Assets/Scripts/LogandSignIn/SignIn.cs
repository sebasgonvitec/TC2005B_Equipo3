// Script that manages Sign-in screen functionality 
// Including the creation of a new user inside the database
// As well as the connection to other game scenes
//
//
// 31-05-2022
// Andreina Sananez

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SignIn : MonoBehaviour
{
    //UI Elements
    public InputField newUsername;
    public InputField newPassword;
    public Button signInButton;
    public Button backButton;
    public Text userExistsTxt;

    //API / DB elements
    [SerializeField] string url; // root 
    [SerializeField] string getUsersEP; //get users endpoint

    //Indicate username doesn't already exist
    //private bool userExists = false;


    // USERS Table Structure
    [System.Serializable]
    public class User
    {
        //public int id_users;
        public string username;
        public string user_password;
        public int num_levels_created;
        //public string first_connection;
        //public string last_connection;
    }

    [System.Serializable]
    public class UserList
    {
        public List<User> users;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        signInButton = signInButton.GetComponent<Button>();
		signInButton.onClick.AddListener(TaskOnClick); 

        backButton = backButton.GetComponent<Button>();
		backButton.onClick.AddListener(TaskOnClickBack);  
    }

    //Log in button on click action
    void TaskOnClickBack(){
        SceneManager.LoadScene("Log_Sign");   
	}


    //Log in button on click action
    void TaskOnClick(){
        StartCoroutine(CheckUsername());
	}

    IEnumerator CheckUsername()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP + "/log/" + newUsername.text))
        {
            yield return www.SendWebRequest();

            //Evaluate web request had code 200 ok
            if (www.result == UnityWebRequest.Result.Success) 
            {
                //Get all users
                string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
                UserList allUsers = JsonUtility.FromJson<UserList>(jsonString);

                //If the username exists already (get not empty)
                if(www.downloadHandler.text != "[]")
                    userExistsTxt.text = "Sorry! This username already exists";
                
                //Start Sign-In coroutine 
                else
                    StartCoroutine(SignInUser());
            }
        }

    }

    IEnumerator SignInUser()
    {
        // Create the object to be sent as json
        User newUser = new User();
        newUser.username = newUsername.text;
        newUser.user_password = newPassword.text;
        //newUser.first_connection = "2022-05-23T18:43:47";
        //newUser.last_connection = "2022-05-23T18:43:47"; 
        
        //Convert C# object to json
        string jsonData = JsonUtility.ToJson(newUser);

        Debug.Log("BODY: " + jsonData);

        // Send using the Put method
        using (UnityWebRequest www = UnityWebRequest.Put(url + getUsersEP, jsonData))
        {
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            //Evaluate web request had code 200 ok
            if (www.result == UnityWebRequest.Result.Success) 
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                SceneManager.LoadScene("LogIn"); //go to login page
            } 
            else 
                Debug.Log("Error: " + www.error); 
        }
    }

}
