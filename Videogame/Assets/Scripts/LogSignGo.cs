using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogSignGo : MonoBehaviour
{
    public Button signInButton;
    public Button logInButton;

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
        SceneManager.LoadScene("SignIn");//go to sign-in page
	}

    //Log in button on click action
    void LogTaskOnClick(){
        SceneManager.LoadScene("LogIn");//go to log-in page
	}
}
