using UnityEngine;
using UnityEngine.UI;

public class DotFade : MonoBehaviour
{
    private Image imageComponent;
    private float fadeTime;
    private float elapsedTime;

    public void Setup(float fadeDuration)
    {
        imageComponent = GetComponent<Image>();
        fadeTime = fadeDuration;
        elapsedTime = 0;
        if (imageComponent == null)
        {
            Debug.LogError("Image component not found on dot prefab.");
        }
    }

    void Update()
    {
        if (imageComponent == null)
            return;

        elapsedTime += Time.deltaTime;
        float alpha = Mathf.PingPong(elapsedTime / fadeTime, 1f);
        Color color = imageComponent.color;
        color.a = alpha;
        imageComponent.color = color;
    }
}