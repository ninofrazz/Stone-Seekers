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
    }

    private IEnumerator wait()
    {
        // Force the canvas to update its elements
        Canvas.ForceUpdateCanvases();


        yield return new WaitForEndOfFrame();

        LoadingScreen.SetActive(false);


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
}
