using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDroppingSlot : MonoBehaviour
{
    DroppingSlot slotScript;
    public GameObject lastSlot;

    void Start()
    {
        slotScript = GetComponent<DroppingSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slotScript.IsDropped == true)
        {
            lastSlot.SetActive(true);
        }
    }
}
