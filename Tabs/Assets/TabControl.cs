using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/// <summary>
/// Original Tab Control by Gordon Biggans (https://twitter.com/digibawb)
/// </summary>

[Serializable]
public class TabControlEntry
{
    [SerializeField]
    private GameObject tab = null;
    public GameObject Tab { get { return tab; } }

    [SerializeField]
    private Button button = null;
    public Button Button { get { return button; } }
}

public class TabControl : MonoBehaviour
{
    [SerializeField]
    private TabControlEntry[] entries = null;

    protected virtual void Start()
    {
        foreach (TabControlEntry entry in entries)
        {
            AddButtonListener(entry);
        }

        if (entries.Length > 0)
        {
            SelectTab(entries[0]);
        }
    }

    private void AddButtonListener(TabControlEntry entry)
    {
        entry.Button.onClick.AddListener(() => SelectTab(entry));
    }

    private void SelectTab(TabControlEntry selectedEntry)
    {
        foreach (TabControlEntry entry in entries)
        {
            bool isSelected = entry == selectedEntry;

            entry.Button.interactable = !isSelected;
            entry.Tab.SetActive(isSelected);
        }
    }
}
