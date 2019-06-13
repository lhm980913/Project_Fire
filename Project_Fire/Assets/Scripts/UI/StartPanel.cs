using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DebugLog()
    {
        Debug.Log("Debug");
    }
}