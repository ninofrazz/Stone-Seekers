using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventUIManager : MonoBehaviour
{
    public int sceneNumber;

    Scene currentScene;

    EventManager EM;

    bool SceneisChecked;
    public bool lastIsDropped;

    public DroppingSlot slot;


    void Start()
    {

        SceneisChecked = false;
        EM = GameObject.Find("-EventManager").GetComponent<EventManager>();
        currentScene = SceneManager.GetActiveScene();


    }


    // Update is called once per frame
    void Update()
    {

        if (slot.IsDropped == true)
        {
            OnDone();
        }
    }


    public void OnMapButtonClick()
    {
        SceneManager.LoadScene("Map");
    }

    public void OnDone()
    {

        // Get the build index of the current scene
        sceneNumber = currentScene.buildIndex;

        EM.eventsDone[sceneNumber - 2] = true;

    }

}
