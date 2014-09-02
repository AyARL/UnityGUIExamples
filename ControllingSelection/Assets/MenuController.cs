using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    // Assign in editor
    [SerializeField]
    private EventSystem eventSystem = null;

    [SerializeField]
    // All selectable UI elements inherit from UnityEngine.UI.Selectable - using this type in the list allows for mixing of different elements
    private List<Selectable> menuElements = null;

    // Use this for initialization
    void Start()
    {
        menuElements = new List<Selectable>();

        // grab all Selectables that are children on current gameObject
        FindMenuElements();

        // Set up the navigation for a circullar list following the order of objects in hierarchy
        /* This can be done in the Editor by setting the Navigation property of each element
         * but just in case you want something custom and dynamic here is how to access that functionality in script */
        CreateNavigation();

        // Set the first element as selected in the EventSystem
        if (menuElements.Count > 0)
        {
            eventSystem.SetSelectedGameObject(menuElements[0].gameObject, new BaseEventData(eventSystem));
        }
    }

    private void FindMenuElements()
    {
        foreach (Transform child in gameObject.transform)
        {
            Selectable selectabe = child.GetComponent<Selectable>();
            if (selectabe != null)
            {
                menuElements.Add(selectabe);
            }
        }
    }

    private void CreateNavigation()
    {
        for (int i = 0; i < menuElements.Count; i++)
        {
            // gets next element in list, at the end of list return first element
            int nextIndex = i + 1;
            nextIndex = nextIndex >= menuElements.Count ? 0 : nextIndex;
            Selectable next = menuElements[(i + 1) % menuElements.Count];

            // gets previous element in list, at the start of list return last element
            int previousIndex = i - 1;
            previousIndex = previousIndex < 0 ? menuElements.Count - 1 : previousIndex;
            Selectable previous = menuElements[previousIndex];

            // Create an initialise new Navigation object, then assign it to the current Selectable
            Navigation navigation = new Navigation() { mode = Navigation.Mode.Explicit, selectOnUp = previous, selectOnDown = next };
            menuElements[i].navigation = navigation;
        }
    }



}
