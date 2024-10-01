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
    public GameObject CompletedText;

    public AudioManager audioManager;

    bool callMehod;
    void Start()
    {
        audioManager = GameObject.Find("-Audio Manager").GetComponent<AudioManager>();
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
        if (!callMehod)
        {
            PlaySounds();

        }
        callMehod = true;

        CompletedText.SetActive(true);

        // Get the build index of the current scene
        sceneNumber = currentScene.buildIndex;

        EM.eventsDone[sceneNumber - 2] = true;
    }

    public void PlaySounds()
    {
        audioManager.Play("Completed");
        audioManager.Stop("Music");

        Debug.Log("completed");
    }

}
