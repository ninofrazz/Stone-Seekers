using UnityEngine;

public class KeepImageOnTop : MonoBehaviour
{
    public RectTransform imageRectTransform;  // Assign the RectTransform of the image

    void Start()
    {
        if (imageRectTransform == null)
        {
            Debug.LogError("ImageRectTransform is not assigned.");
            return;
        }

        // Set the image as the last sibling
        imageRectTransform.SetAsLastSibling();
    }
}
