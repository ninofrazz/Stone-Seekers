using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public GameObject worldCanvas;
    public Camera mainCamera; // Reference to your camera

    public float referenceWidth = 1920f; // Reference width
    public float referenceHeight = 1080f; // Reference height
    private void Start()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        transform.position = new Vector3(screenCenter.x, screenCenter.y, -1005);

        worldCanvas.transform.position = new Vector3(screenCenter.x, screenCenter.y, 0);

        referenceHeight = Screen.height;
        referenceWidth = Screen.width;
    }
}
