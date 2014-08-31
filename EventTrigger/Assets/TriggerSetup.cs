using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class TriggerSetup : MonoBehaviour
{
    EventTrigger eventTrigger = null;

    [SerializeField]
    private Text textField = null;

    // Use this for initialization
    void Start()
    {
        eventTrigger = gameObject.GetComponent<EventTrigger>();

        AddEventTrigger(OnPointerClick, EventTriggerType.PointerClick);
        AddEventTrigger(OnPointerEnter, EventTriggerType.PointerEnter);
        AddEventTrigger(OnPointerEnter, EventTriggerType.PointerExit);
        AddEventTrigger(OnPointerDown, EventTriggerType.PointerDown);
        AddEventTrigger(OnPointerUp, EventTriggerType.PointerUp);
        AddEventTrigger(OnDrag, EventTriggerType.Drag);
        AddEventTrigger(OnDrop, EventTriggerType.Drop);
        AddEventTrigger(OnScroll, EventTriggerType.Scroll);
    }


    #region TriggerEventsSetup

    private void AddEventTrigger(UnityAction action, EventTriggerType triggerType)
    {
        // Create a nee TriggerEvent and add a listener
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action()); // you can capture and pass the event data to the listener

        // Create and initialise EventTrigger.Entry using the created TriggerEvent
        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

        // Add the EventTrigger.Entry to delegates list on the EventTrigger
        eventTrigger.delegates.Add(entry);
    }

    private void AddEventTrigger(UnityAction<BaseEventData> action, EventTriggerType triggerType)
    {
        // Create a nee TriggerEvent and add a listener
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action(eventData)); // you can capture and pass the event data to the listener

        // Create and initialise EventTrigger.Entry using the created TriggerEvent
        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

        // Add the EventTrigger.Entry to delegates list on the EventTrigger
        eventTrigger.delegates.Add(entry);
    }

    #endregion


    #region Callbacks

    private void OnPointerClick(BaseEventData data)
    {
        textField.text = "OnPointerClick " + data.selectedObject;
    }

    private void OnPointerEnter()
    {
        textField.text = "OnPointerEnter";
    }

    private void OnPointerExit()
    {
        textField.text = "OnPointerExit";
    }

    private void OnPointerDown()
    {
        textField.text = "OnPointerDown";
    }

    private void OnPointerUp()
    {
        textField.text = "OnPointerUp";
    } 

    private void OnDrag()
    {
        textField.text = "OnDrag";
    }

    private void OnDrop()
    {
        textField.text = "OnDrop";
    }

    private void OnScroll()
    {
        textField.text = "OnScroll";
    } 
    #endregion


}
