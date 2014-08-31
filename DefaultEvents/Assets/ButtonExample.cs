using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ButtonExample : MonoBehaviour
{
    // Assigned in editor
    [SerializeField]
    private Button actionButton = null;

    [SerializeField]
    private Button disableListenerButton = null;

    [SerializeField]
    private Text clickCounterText = null;

    UnityAction action = null;
    private int clickCounter = 0;

    private void Start()
    {
        /* Add a listener to the button's onClick event
         The code between { } will be executed when the button is clicked
         Any values for the variables will also be captured at the time of the event (and not at the time of creating the listener) */

        action = () => { clickCounter += 1; SetClickCount(clickCounter); }; // save the event to a variable so it can be removed later on
        actionButton.onClick.AddListener(action);

        disableListenerButton.onClick.AddListener(() => DisableListener()); // create and add listener at once - can only be removed by onClick.RemoveAllListeners();
    }

    private void SetClickCount(int clicks)
    {
        clickCounterText.text = clicks.ToString();
    }

    private void DisableListener()
    {
        if (action != null)
        {
            actionButton.onClick.RemoveListener(action);
        }
    }
}
