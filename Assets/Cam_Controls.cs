using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cam_Controls : MonoBehaviour
{
    public float moveSpeed = 0.1f; // Speed of the camera movement
    private Vector2 lastTouchPosition;
    public bool isDragging = false;
    public bool isZooming = false;

    public Transform PlayerObj;

    public float distance;

    public float minDistance = 2.0f;
    public float maxDistance = 10.0f;

    public float rotationSensitivity = 0.1f;

    private float currentAngleX = 0f; // Current rotation angle around the player
    private float currentAngleY = 0f; // Horizontal rotation angle

    bool cameraMoving = false;

    public GameObject index;

    void Update()
    {
        if (!index.activeInHierarchy)
        {
            // Calculate the current distance between the camera and the player object
            distance = Vector3.Distance(transform.position, PlayerObj.position);
            // Handle touch input for rotating the camera
            // Handle touch input for rotating the camera
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Store the initial touch position
                    lastTouchPosition = touch.position;
                    isDragging = true;
                }
                else if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    // Calculate the amount the touch has moved
                    Vector2 touchDelta = touch.position - lastTouchPosition;

                    // Update the last touch position
                    lastTouchPosition = touch.position;

                    // Calculate rotation angles
                    float rotationX = touchDelta.x * rotationSensitivity; // Horizontal movement
                    float rotationY = touchDelta.y * rotationSensitivity; // Vertical movement

                    // Update the rotation angles
                    currentAngleY += rotationX; // Horizontal rotation around the vertical axis
                    currentAngleX -= rotationY; // Vertical rotation around the horizontal axis

                    // Clamp vertical angle to avoid flipping
                    currentAngleX = Mathf.Clamp(currentAngleX, -89f, 89f);

                    // Calculate new position
                    Quaternion rotation = Quaternion.Euler(60, currentAngleY, 0);
                    Vector3 direction = rotation * new Vector3(0, 0, -distance);
                    transform.position = PlayerObj.position + direction;

                    // Make sure the camera is looking at the player
                    transform.LookAt(PlayerObj);

                    cameraMoving = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isDragging = false;
                }
            }

            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                // Calculate the distance between the touches in each frame.
                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                float touchDeltaMag = (touch1.position - touch2.position).magnitude;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // Move the camera along its local z-axis based on the difference in distance.
                float moveAmount = deltaMagnitudeDiff * moveSpeed;

                // Calculate the new distance
                float newDistance = Mathf.Clamp(distance - moveAmount, minDistance, maxDistance);

                // Move the camera to the new distance
                Vector3 direction = (transform.position - PlayerObj.position).normalized;
                transform.position = PlayerObj.position + direction * newDistance;


                isZooming = true;
                isDragging = false;


            }
            else
                isZooming = false;

            if (isDragging)
            {
                isZooming = false;

            }

            if (isZooming)
            {
                isDragging = false;
            }
        }
    }

}