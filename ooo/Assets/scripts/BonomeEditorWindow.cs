using System;
using UnityEditor;
using UnityEngine;

public class BonomeEditorWindow : EditorWindow
{
    public BonomeDataa data;

    [MenuItem("Tools/Bonome")]

    public static void ShowWindow()
    {
        GetWindow<BonomeEditorWindow>("Bonome");
    }

    private void OnGUI()
    {
        data = (BonomeDataa)EditorGUILayout.ObjectField("data", data, typeof(BonomeDataa), false);

        data.speed = EditorGUILayout.FloatField("speed", data.speed);
    }
}
