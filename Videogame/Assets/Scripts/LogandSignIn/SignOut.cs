using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class SignOut : MonoBehaviour
{

    public Button signOutButton;

    // Start is called before the first frame update
    void Start()
    {
        signOutButton = signOutButton.GetComponent<Button>();
		signOutButton.onClick.AddListener(SignOutTaskOnClick);
    }

    //Sign out button on click action
    void SignOutTaskOnClick(){
        PlayerPrefs.DeleteKey("id_user"); //remove user login
        SceneManager.LoadScene("Log_Sign");//go to log/sign page
    }
}
