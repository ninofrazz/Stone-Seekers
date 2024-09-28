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

    private int index;

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
