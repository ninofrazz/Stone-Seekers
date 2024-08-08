using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    public DroppingSlot slot;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }

        // Sorting layer fix (first point only)
        if (slot != null)
        {
            if (slot.IsDropped)
            {
                lr.sortingOrder = 0;
            }
        }
    }
}
