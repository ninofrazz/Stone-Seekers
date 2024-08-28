using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject eventPanelUserInRange;
    [SerializeField]
    private GameObject eventPanelUserNotInRange;

    bool isUIPanelActive;
    int tempEvent;

    [SerializeField]
    private EventManager eventManager;

    public int currentIndex = 0;



    public string[] texts;
    public TMP_Text displayText;

    public Sprite[] images;
    [SerializeField]
    public Image displayImage;

    public IndexManager IndexManager;


    void Start()
    {
        texts = IndexManager.dexTitle;
        images = IndexManager.dexImages;

    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = texts[currentIndex];
        displayImage.sprite = images[currentIndex];

        if (displayImage != null)
        {
            displayImage.preserveAspect = true;
        }
    }

    public void DisplayStartEventPanel(int eventID)
    {
        if (!isUIPanelActive)
        {
            tempEvent = eventID;

            eventPanelUserInRange.SetActive(true);
            currentIndex = eventID - 1;
            isUIPanelActive = true;

        }
    }

    public void onJoinButtonClick()
    {
        eventManager.ActivateEvent(tempEvent);
    }

    public void DisplayUsetNotInRange()
    {
        if (!isUIPanelActive)
        {
            eventPanelUserNotInRange.SetActive(true);

            isUIPanelActive = true;
        }
    }

    public void CloseButtonClick()
    {
        eventPanelUserInRange.SetActive(false);
        eventPanelUserNotInRange.SetActive(false);
        isUIPanelActive = false;
    }
}
