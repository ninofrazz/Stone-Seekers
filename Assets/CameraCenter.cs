using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public GameObject worldCanvas;
    public Camera mainCamera; // Reference to your camera
    public float desiredWidth = 10f;  // Desired width of the camera view


    public float referenceWidth = 1920f; // Reference width
    public float referenceHeight = 1080f; // Reference height
    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        //transform.position = new Vector3(screenCenter.x, screenCenter.y, -1005);

        //worldCanvas.transform.position = new Vector3(screenCenter.x, screenCenter.y, 0);

        transform.position = worldCanvas.transform.position + new Vector3(0, 0, -1005);

        referenceHeight = Screen.height;
        referenceWidth = Screen.width;

        AdjustCameraSize();
    }
    void AdjustCameraSize()
    {
        if (GetComponent<Camera>().orthographic)
        {
            // Get the aspect ratio of the screen
            float aspectRatio = (float)Screen.width / Screen.height;

            // Calculate the orthographic size based on the desired width and the aspect ratio
            GetComponent<Camera>().orthographicSize = referenceWidth / aspectRatio / 2;
        }
    }

}
