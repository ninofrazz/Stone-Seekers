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

    public GameObject LoadingScreen;
    public GameObject map;
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
        LoadingScreen = GameObject.Find("Loading");
        LoadEventsDone();
    }

    private IEnumerator wait()
    {
        // Force the canvas to update its elements
        Canvas.ForceUpdateCanvases();


        yield return new WaitForEndOfFrame();

        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(false);
        }


        // Wait until the end of the frame

    }
    // Update is called once per frame
    void Update()
    {

        if (map.transform.childCount > 0)
        {

            StartCoroutine(wait());

        }
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        LoadingScreen.SetActive(false);

        yield return null;
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

    public void SaveEventsDone()
    {
        string boolString = string.Join(",", eventsDone); // Convert bool array to a comma-separated string
        PlayerPrefs.SetString("EventsDone", boolString);  // Save the string in PlayerPrefs with key "EventsDone"
        PlayerPrefs.Save();  // Ensure the data is saved
        Debug.Log("Saving");
    }

    public void LoadEventsDone()
    {
        string boolString = PlayerPrefs.GetString("EventsDone", string.Empty); // Load the string from PlayerPrefs
        Debug.Log("Loading");

        if (!string.IsNullOrEmpty(boolString))
        {
            string[] boolStrings = boolString.Split(','); // Split the string into parts
            eventsDone = new bool[boolStrings.Length]; // Initialize the bool array with the correct size

            for (int i = 0; i < boolStrings.Length; i++)
            {
                eventsDone[i] = bool.Parse(boolStrings[i]); // Convert the string back to a bool
            }
        }
        else
        {
            //eventsDone = new bool[0]; // Initialize with an empty array if no data is found
        }
    }

}
