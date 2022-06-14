// Script that manages Log-in screen functionality 
// Including the authentication of an already registered user
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

public class LogIn : MonoBehaviour
{
    //UI Elements
    public InputField username;
    public InputField password;
    public Button logInButton;
    public Button signInButton;
    public Text errorText;

    //API / DB elements
    [SerializeField] string url; // root 
    [SerializeField] string getUsersEP; //get users endpoint
    [SerializeField] string getSPLastConnectionEP; //get stored procedure EP
     [SerializeField] string getSPLogTimesEP; //get stored procedure EP



    // USERS Table Structure
    [System.Serializable]
    public class User
    {
        public int id_user;
        public string username;
        public string user_password;
        public int num_levels_created;
        public string first_connection;
        public string last_connection;
    }

    [System.Serializable]
    public class UserList
    {
        public List<User> users;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        logInButton = logInButton.GetComponent<Button>();
		logInButton.onClick.AddListener(LogTaskOnClick);  

        signInButton = signInButton.GetComponent<Button>();
		signInButton.onClick.AddListener(SignTaskOnClick);  
    }

    //Sign in button on click action
    void SignTaskOnClick(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);//go to sign-in page
	}

    //Log in button on click action
    void LogTaskOnClick(){
        StartCoroutine(LogInUser());
	}

    
    IEnumerator LogInUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP + username.text))
        {
            yield return www.SendWebRequest();

            //Evaluate web request had code 200 ok
            if (www.result == UnityWebRequest.Result.Success) 
            {
                //Get all users
                string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
                UserList allUsers = JsonUtility.FromJson<UserList>(jsonString);

                //Evaluate the username entered was found on the data base (list not empty)
                if(www.downloadHandler.text != "[]")
                {
                    //Get user with the input username
                    User userEntry = allUsers.users[0];

                    //Evalate if the input password is the same as the one registered
                    if(userEntry.user_password == password.text)
                    {
                        //Debug.Log("You entered to your account!"); 
                        //Debug.Log(PlayerPrefs.GetInt("id_user"));
                        PlayerPrefs.SetInt("id_user", userEntry.id_user);
                        CallLastConnectionSP(userEntry.id_user);
                        CallLogInCountSP(userEntry.id_user);
                        SceneManager.LoadScene(3, LoadSceneMode.Single); //go to menu page
                    }
                        
                    else
                        errorText.text = "Incorrect Password"; 

                }
                else
                    errorText.text = "Username not found"; 
             
            } 
            
            //Else diplay corresponding http error
            else 
                Debug.Log("Error: " + www.error);
            
        }
    }

    //Function that starts coroutine to call last connection stored procedure
    public void CallLastConnectionSP(int userId)
    {
        StartCoroutine(UpdateLastConnection(userId));
    }

    //Calls stored procedure to update the last connection of the user that logged in
    IEnumerator UpdateLastConnection(int userId)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getSPLastConnectionEP + userId))
        {
            yield return www.SendWebRequest();
        }
        
    }

    //Function that starts coroutine to call login count stored procedure
    public void CallLogInCountSP(int userId)
    {
        StartCoroutine(UpdateLogTimes(userId));
    }

    //Calls stored procedure to update the login count of the user that logged in
    IEnumerator UpdateLogTimes(int userId)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getSPLogTimesEP + userId))
        {
            yield return www.SendWebRequest();
        }
        
    }



   
}
