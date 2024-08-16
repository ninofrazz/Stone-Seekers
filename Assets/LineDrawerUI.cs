using UnityEngine;
using UnityEngine.UI;

public class LineDrawerUI : MonoBehaviour
{
    public GameObject linePrefab; // Assign the prefab of the line image
    public Canvas canvas; // Assign the Canvas
    public Vector2 startPoint;
    public Vector2 endPoint;

    void Start()
    {
        DrawLine(startPoint, endPoint);
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        if (linePrefab == null || canvas == null)
        {
            Debug.LogError("Line Prefab or Canvas is not assigned.");
            return;
        }

        GameObject lineObject = Instantiate(linePrefab, canvas.transform);
        RectTransform rectTransform = lineObject.GetComponent<RectTransform>();

        // Set the line's start and end points
        Vector2 direction = end - start;
        float distance = direction.magnitude;
        direction.Normalize();

        // Set the position and size of the line
        rectTransform.sizeDelta = new Vector2(distance, rectTransform.sizeDelta.y);
        rectTransform.position = start;
        rectTransform.rotation = Quaternion.FromToRotation(Vector2.right, direction);
    }
}
