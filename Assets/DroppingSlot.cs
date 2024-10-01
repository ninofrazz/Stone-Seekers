using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppingSlot : MonoBehaviour, IDropHandler
{
    public bool IsDropped;
    public int id;
    private static int nextId = 0;

    public GameObject nextobj;
    public GameObject nextReceiver;
    public AudioManager audioManager;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragAndDrop draggableItem = dropped.GetComponent<DragAndDrop>();

        if (transform.childCount == 0)
        {
            audioManager.Play("Stone");
            draggableItem.parentAfterDrag = transform;

        }

    }

    private void Start()
    {
        audioManager = GameObject.Find("-Audio Manager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            IsDropped = false;
        }
        else
        {
            IsDropped = true;

            GetComponentInChildren<DragAndDrop>().isDraggable = false;
        }

        if (IsDropped)
        {
            if (nextobj != null)
            {
                nextobj.SetActive(true);
            }
            if (nextReceiver != null)
            {
                nextReceiver.SetActive(true);
            }
        }

    }
}


