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
    private Button submitButton = null;

    [SerializeField]
    private Text textDisplay = null;

    UnityAction<string> inputAction = null;    // The InputField.onSubmit event sends one string argument that the action needs to accept
    UnityAction buttonAction = null;

    // Use this for initialization
    void Start()
    {
        // Add a listener to be executed when a submit key is pressed - Enter by default
        inputAction = (value) => OnInputSubmitted(value); // value represents the argument that will be passed from InputField.OnSubmit
        inputField.onSubmit.AddListener(inputAction);

        // Add functionality to submit the InputField using a button
        buttonAction = () => OnInputSubmitted(inputField.value); // capture the value of the InputField when the button is pressed
        submitButton.onClick.AddListener(buttonAction);
    }

    private void OnInputSubmitted(string value)
    {
        textDisplay.text = value;
    }
}
