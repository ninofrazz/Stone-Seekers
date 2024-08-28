using UnityEngine;

public class DistanceCircleDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float circleRadius = 10f; // Default radius, can be set dynamically
    public int segments = 50; // Number of segments in the circle
    public Transform playerTransform; // The player's transform
    public float offset;
    public EventManager eventManager;

    void Start()
    {
        // Initialize the LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.positionCount = segments + 1; // Extra segment to close the circle
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true; // To close the circle
        DrawCircle();
    }

    void Update()
    {
        circleRadius = eventManager.maxDistance / 3.9f;
        // Ensure the circle follows the player's position
        if (playerTransform != null)
        {
            transform.position = playerTransform.position;
        }
        DrawCircle();
    }

    public void UpdateCircleRadius(float newRadius)
    {
        circleRadius = newRadius;
        DrawCircle();
    }

    private void DrawCircle()
    {
        float deltaTheta = (2f * Mathf.PI) / segments;
        float theta = 0f;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = circleRadius * Mathf.Cos(theta);
            float z = circleRadius * Mathf.Sin(theta);
            lineRenderer.SetPosition(i, new Vector3(x, offset, z));
            theta += deltaTheta;
        }
    }
}
