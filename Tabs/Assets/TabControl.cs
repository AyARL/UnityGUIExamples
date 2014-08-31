using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Original Tab Control by Gordon Biggans (https://twitter.com/digibawb)
/// </summary>

[Serializable]
public class TabControlEntry
{
    [SerializeField]
    private GameObject panel = null;
    public GameObject Panel { get { return panel; } }

    [SerializeField]
    private Button tab = null;
    public Button Tab { get { return tab; } }
}

public class TabControl : MonoBehaviour
{
    [SerializeField]
    private List<TabControlEntry> entries = null;

    [SerializeField]
    private GameObject panelContainer = null;
    [SerializeField]
    private GameObject tabContainer = null;

    [SerializeField]
    private GameObject tabPrefab = null;
    [SerializeField]
    private GameObject panelPrefab = null;

    protected virtual void Start()
    {
        foreach (TabControlEntry entry in entries)
        {
            AddButtonListener(entry);
        }

        if (entries.Count > 0)
        {
            SelectTab(entries[0]);
        }
    }

    public void AddEntry(TabControlEntry entry)
    {
        entries.Add(entry);
    }

    private void AddButtonListener(TabControlEntry entry)
    {
        entry.Tab.onClick.AddListener(() => SelectTab(entry));
    }

    private void SelectTab(TabControlEntry selectedEntry)
    {
        foreach (TabControlEntry entry in entries)
        {
            bool isSelected = entry == selectedEntry;

            entry.Tab.interactable = !isSelected;
            entry.Panel.SetActive(isSelected);
        }
    }
}
