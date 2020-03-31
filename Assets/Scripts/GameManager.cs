using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentScene = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Alert: More than one Game Manager detected, Deleting extra(s)");
        }
    }

    public void LoadLevel(string levelToLoad)
    {//Danger, Maybe don't use
        SceneManager.LoadScene(levelToLoad);
        currentScene++;
    }

    public void LoadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
        currentScene++;
    }
}