using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    public GameObject dotPrefab;  // Assign your dot prefab in the inspector
    public int numberOfDots = 100;  // Number of dots to spawn
    public RectTransform spawnArea;  // Assign the RectTransform of the Panel or Canvas area
    public float minFadeTime = 1f;  // Minimum time for fading
    public float maxFadeTime = 3f;  // Maximum time for fading
    public float minDotSize = 10f;  // Minimum size for the dots
    public float maxDotSize = 50f;  // Maximum size for the dots

    // New variables to control sorting
    public string sortingLayerName = "Default";  // The name of the sorting layer to use
    public int sortingOrder = 0;  // The sorting order of the dots

    void Start()
    {
        if (dotPrefab == null || spawnArea == null)
        {
            Debug.LogError("DotSpawner is not properly set up.");
            return;
        }

        for (int i = 0; i < numberOfDots; i++)
        {
            SpawnDot();
        }
    }

    void SpawnDot()
    {
        GameObject dot = Instantiate(dotPrefab);
        dot.transform.SetParent(spawnArea, false);

        RectTransform dotRectTransform = dot.GetComponent<RectTransform>();

        // Randomize size
        float size = Random.Range(minDotSize, maxDotSize);
        dotRectTransform.sizeDelta = new Vector2(size, size);

        // Calculate random position within the spawn area
        float x = Random.Range(-spawnArea.rect.width / 2f, spawnArea.rect.width / 2f);
        float y = Random.Range(-spawnArea.rect.height / 2f, spawnArea.rect.height / 2f);

        dotRectTransform.anchoredPosition = new Vector2(x, y);

        // Add a Canvas component and control sorting layer
        Canvas dotCanvas = dot.AddComponent<Canvas>();
        dotCanvas.overrideSorting = true;  // Allow overriding sorting
        dotCanvas.sortingLayerName = sortingLayerName;  // Set the sorting layer
        dotCanvas.sortingOrder = sortingOrder;  // Set the sorting order

        // Add the fade effect
        DotFade fade = dot.AddComponent<DotFade>();
        float fadeDuration = Random.Range(minFadeTime, maxFadeTime);
        fade.Setup(fadeDuration);
    }
}
