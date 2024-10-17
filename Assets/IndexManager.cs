using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IndexManager : MonoBehaviour
{
    public EventManager EM;

    public Button[] buttons;

    public GameObject index;
    public GameObject indexButton;
    public GameObject Description;
    public GameObject Credits;
    public GameObject Tutorial;
    public GameObject DialogeBox;

    [SerializeField]
    public Sprite[] dexImages;


    public string[] dexTitle;
    public string[] dexText;


    public TMP_Text DescriptionTitle;
    public TMP_Text DescriptionText;
    public Image DescriptionImage;

    public Scrollbar scrollbar;

    public int receivedID;

    private const string FirstTimeKey = "IsFirstTime";

    public int PlayerprefsFistBoot;

    public bool IsFirstBoot;


    // Start is called before the first frame update
    void Start()
    {
        EM = GameObject.Find("-EventManager").GetComponent<EventManager>();
        scrollbar.value = 1;
        scrollbar.size = 0.4f;

        // PlayerPrefs.SetInt(FirstTimeKey, PlayerprefsFistBoot);
        //PlayerPrefs.DeleteAll(); // This will clear all PlayerPrefs data for testing
        //PlayerPrefs.Save(); // Ensure the changes are saved

        // Checking if this is the first time the game is launched
        if (PlayerPrefs.GetInt(FirstTimeKey) == 0)
        {
            InitializeFirstTime(); // Run tutorial or first-time setup
            PlayerPrefs.SetInt(FirstTimeKey, 1); // Mark first boot as done
            //PlayerPrefs.Save(); // Save changes
        }
        if (PlayerPrefs.GetInt(FirstTimeKey) == 1)

        {
        }
        //method();
    }

    public void method()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void InitializeFirstTime()
    {
        OpenTutorial();
    }

    public void ReceiveID(int id)
    {
        receivedID = id;
        DescriptionTitle.text = dexTitle[id];
        DescriptionText.text = dexText[id];
        DescriptionImage.sprite = dexImages[id];
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = EM.eventsDone[i];
        }

        if (DescriptionImage != null)
        {
            DescriptionImage.preserveAspect = true;
        }

        PlayerprefsFistBoot = PlayerPrefs.GetInt(FirstTimeKey, 0);
    }

    public void OpenIndex()
    {
        indexButton.SetActive(false);
        index.SetActive(true);
    }
    public void CloseIndex()
    {
        indexButton.SetActive(true);
        index.SetActive(false);
    }
    public void OpenDescription()
    {
        Description.SetActive(true);
    }
    public void CloseDescription()
    {
        Description.SetActive(false);
    }
    public void OpenCredits()
    {
        Credits.SetActive(true);
    }
    public void CloseCredits()
    {
        Credits.SetActive(false);
    }
    public void OpenTutorial()
    {
        Tutorial.SetActive(true);
        DialogeBox.SetActive(true);
        DialogeBox.GetComponent<DialogueBox>().StartDialogue();
    }
    public void CloseTutorial()
    {
        Tutorial.SetActive(false);
    }
}

