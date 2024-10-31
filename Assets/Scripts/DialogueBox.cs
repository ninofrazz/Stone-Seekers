using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public GameObject TutorialCanvas;

    public int index;

    public GameObject[] tutImages;

    void Start()
    {
        // textComponent.text = string.Empty;
        // StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // If the current text is fully displayed
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // If the text is still being typed out, skip to the end
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        //manuel input of the diaòogue

        if (index == 4)
        {
            tutImages[0].SetActive(true);
        }
        else
        {
            tutImages[0].SetActive(false);
        }
        if (index == 5)
        {
            tutImages[1].SetActive(true);
        }
        else
        {
            tutImages[1].SetActive(false);
        }
        if (index == 7)
        {
            tutImages[2].SetActive(true);
        }
        else
        {
            tutImages[2].SetActive(false);
        }
        if (index == 8)
        {
            tutImages[3].SetActive(true);
        }
        else
        {
            tutImages[3].SetActive(false);
        }
        if (index == 9)
        {
            tutImages[4].SetActive(true);
        }
        else
        {
            tutImages[4].SetActive(false);
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty; // Clear the text before starting
        foreach (char c in lines[index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            //gameObject.SetActive(false);
            index++;
            TutorialCanvas.SetActive(false);
        }
    }
}
