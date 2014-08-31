using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ToggleExample : MonoBehaviour
{
    // Set in editor
    [SerializeField]
    private Toggle toggle = null;

    [SerializeField]
    private Text toggleStatusText = null;

    UnityAction<bool> action = null;    // The Toggle.OnValueChanged event sends one bool argument that the action needs to accept

    // Use this for initialization
    void Start()
    {
        toggleStatusText.text = toggle.isOn.ToString(); // grab the inital toggle value;


        // create an action to attach to the toggle
        action = (value) => OnToggleChange(value);  // value represents the argument that will be passed from Toggle.OnValueChanged

        toggle.onValueChanged.AddListener(action);
    }

    private void OnToggleChange(bool value)
    {
        toggleStatusText.text = value.ToString();
    }
}
