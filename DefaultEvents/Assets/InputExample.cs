using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class InputExample : MonoBehaviour
{
    // Assign in editor
    [SerializeField]
    private InputField inputField = null;

    [SerializeField]
    private Text textDisplay = null;

    // Use this for initialization
    void Start()
    {
        // Add a Submit Event object with a listener.
        /* Note: onEndEdit is called both when Submit key is pressed and when you click away from the field.
         * If you want to build a larger form or not submit right away for any other reason, don't use this.
         * Instead create a button that calls a function, which then reads the value of inputField.text
         */
        InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(OnInputSubmitted);
        inputField.onEndEdit = submitEvent;
    }

    private void OnInputSubmitted(string value)
    {
        textDisplay.text = value;
    }
}
