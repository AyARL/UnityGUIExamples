using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NavigationButton : MonoBehaviour
{
    private Button button = null;

    [SerializeField]
    private Selectable nextElement = null;

    [SerializeField]
    private EventSystem eventSystem = null;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        if (button != null && nextElement != null && eventSystem != null)
        {
            button.onClick.AddListener(() => eventSystem.SetSelectedGameObject(nextElement.gameObject, new BaseEventData(eventSystem)));
        }
    }


}
