using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    public void LoadMaker()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadLogSign()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void LoadLogin()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    public void LoadSignIn()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}
