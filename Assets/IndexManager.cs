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

    [SerializeField]
    public Sprite[] dexImages;


    public string[] dexTitle;
    public string[] dexText;


    public TMP_Text DescriptionTitle;
    public TMP_Text DescriptionText;
    public Image DescriptionImage;

    public Scrollbar scrollbar;

    public int receivedID;



    // Start is called before the first frame update
    void Start()
    {
        EM = GameObject.Find("-EventManager").GetComponent<EventManager>();
        scrollbar.value = 1;
        scrollbar.size = 0.4f;

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
}

