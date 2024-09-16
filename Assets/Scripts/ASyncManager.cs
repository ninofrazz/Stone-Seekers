using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncManager : MonoBehaviour
{
    public GameObject loadingscreen;  // The loading screen UI
    public GameObject mainmenu;
    public GameObject becar;
    // The main menu UI
    //public Slider progressBar;        // The UI slider for progress bar
    //  public Text progressText;         // The UI text component for progress percentage


    public void LoadLevel(string levelToLoad)
    {
        Debug.Log("Starting to load scene: " + levelToLoad);  // Debugging log
        loadingscreen.SetActive(true);
        mainmenu.SetActive(false);
        becar.SetActive(false);

        // Ensure the loading screen persists across scenes
        DontDestroyOnLoad(loadingscreen);


        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("map");


        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //loadingscreen.gameObject.SetActive(false);
    }

    // Hide the loading screen after the new scene has fully loaded
    // loadingscreen.SetActive(false);

}
