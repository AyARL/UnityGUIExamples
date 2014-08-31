using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TabControl))]
public class TabControlInspector : Editor
{
    
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("panelContainer"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tabContainer"), true);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("panelPrefab"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tabPrefab"), true);


        if (GUILayout.Button("Add new Tab"))
        {
            CreateTab();
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("entries"), true);


        serializedObject.ApplyModifiedProperties();
    }

    private void CreateTab()
    {
        GameObject panel = Instantiate(serializedObject.FindProperty("panelPrefab").objectReferenceValue) as GameObject;
        panel.transform.SetParent((serializedObject.FindProperty("panelContainer").objectReferenceValue as GameObject).transform, false);

        GameObject tab = Instantiate(serializedObject.FindProperty("tabPrefab").objectReferenceValue) as GameObject;
        tab.transform.SetParent((serializedObject.FindProperty("tabContainer").objectReferenceValue as GameObject).transform, false);

        SerializedProperty entries = serializedObject.FindProperty("entries");
        entries.arraySize++;

        serializedObject.ApplyModifiedProperties();

        entries.GetArrayElementAtIndex(entries.arraySize - 1).FindPropertyRelative("panel").objectReferenceValue = panel;
        entries.GetArrayElementAtIndex(entries.arraySize - 1).FindPropertyRelative("tab").objectReferenceValue = tab;
    }
}
