using UnityEngine;
using UnityEngine.UI;

public class ButtonID : MonoBehaviour
{
    public int ID;
    public IndexManager receiver; // Reference to the Receiver script

    void Start()
    {
        // Get the Button component attached to the same GameObject
        Button button = GetComponent<Button>();

        // Register the OnButtonClick method to the button's onClick event
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // Send the ID to the receiver's ReceiveID method
        if (receiver != null)
        {
            receiver.ReceiveID(ID);
        }
    }
}