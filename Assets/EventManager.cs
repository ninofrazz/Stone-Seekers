using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EventManager : MonoBehaviour
{

    public int maxDistance = 70;

    public bool[] eventsDone;

    private static EventManager instance;

    string locName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateEvent(int eventID)
    {
        locName = eventID.ToString();
        SceneManager.LoadScene("Loc" + locName);
        /*
                if (eventID == 1)
                {
                    SceneManager.LoadScene("Loc1");

                }
                else if (eventID == 2)
                {
                    SceneManager.LoadScene("Loc2");

                }
        */
    }
    public static EventManager Instance
    {
        get { return instance; }
    }
}
