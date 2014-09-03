using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Builds a Navigation scheme for children of this game object that include a Selectable component (eg. Button, Toggle, InputField)
/// THIS CAN BE ACHIEVED IN THE EDITOR: Use the Navigation property on the Selectable to set it up, but in case you want a custom, dynamic system, this shows how to interact with various elements through script.
/// </summary>

public class MenuController : MonoBehaviour
{
    // Assign in editor
    [SerializeField]
    private EventSystem eventSystem = null;

    public enum NavigationMode { Vertical, Horizontal }
    [SerializeField]
    private NavigationMode navigationMode = NavigationMode.Vertical;

    [SerializeField]
    private bool circular = false;

    [SerializeField]
    private bool startingPoint = false;

    private List<Selectable> menuElements = null; // All selectable UI elements inherit from UnityEngine.UI.Selectable - using this type in the list allows for mixing of different elements

    void Start()
    {
        BuildNavigation();
    }

    private void BuildNavigation()
    {
        // grab all Selectables that are children on current gameObject
        FindMenuElements();

        // Set up the navigation for a circullar list following the order of objects in hierarchy and ignoring non-interactable elements
        CreateNavigation();

        // Set the first interactable element as selected in the EventSystem
        if (startingPoint && menuElements.Count > 0)
        {
            Selectable firstSelected = menuElements.FirstOrDefault((e) => e.interactable);
            if (firstSelected != null)
            {
                eventSystem.SetSelectedGameObject(firstSelected.gameObject, new BaseEventData(eventSystem));
            }
            else
            {
                eventSystem.SetSelectedGameObject(menuElements[0].gameObject, new BaseEventData(eventSystem));
            }
        }

    }

    private void FindMenuElements()
    {
        menuElements = new List<Selectable>();

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
            Selectable next = null;
            Selectable previous = null;
            FindNeighbours(i, ref next, ref previous);

            // Create an initialise new Navigation object, then assign it to the current Selectable
            Navigation navigation;
            switch (navigationMode)
            {
                case NavigationMode.Vertical:
                    navigation = new Navigation() { mode = Navigation.Mode.Explicit, selectOnUp = previous, selectOnDown = next };
                    break;

                case NavigationMode.Horizontal:
                    navigation = new Navigation() { mode = Navigation.Mode.Explicit, selectOnLeft = previous, selectOnRight = next };
                    break;

                default:
                    navigation = new Navigation() { mode = Navigation.Mode.Explicit };
                    break;
            }

            menuElements[i].navigation = navigation;
        }
    }

    private void FindNeighbours(int i, ref Selectable next, ref Selectable previous)
    {
        int nextIndex = i + 1;
        int previousIndex = i - 1;
        if (circular)
        {
            nextIndex %= menuElements.Count;
            previousIndex = previousIndex < 0 ? menuElements.Count - 1 : previousIndex;

            next = menuElements[nextIndex];
            previous = menuElements[previousIndex];

        }
        else
        {
            if (nextIndex < menuElements.Count)
            {
                next = menuElements[nextIndex];
            }
            if (previousIndex >= 0)
            {
                previous = menuElements[previousIndex];
            }
        }
    }
}
