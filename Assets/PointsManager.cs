using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public bool[] points;
    public GameObject[] receiverAndPoint;
    void Start()
    {
        UpdateObjects();

    }

    void Update()
    {
        UpdateObjects();
    }

    void UpdateObjects()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (i < receiverAndPoint.Length)
            {
                receiverAndPoint[i].SetActive(points[i]);
            }
        }
    }
}
