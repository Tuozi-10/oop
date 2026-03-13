using UnityEngine;
using UnityEditor;

public class EntityEditorWindow : EditorWindow
{
    public EntityParameters dataCible;

    [MenuItem("Tools/PlayerModifier")]
    public static void ShowWindow()
    {
        GetWindow<EntityEditorWindow>("PlayerModifier");
    }

    private void OnGUI()
    {
        GUILayout.Label("Entity modifier", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        dataCible = (EntityParameters)EditorGUILayout.ObjectField("Entity to modify", dataCible, typeof(EntityParameters), false);

        if (dataCible != null)
        {
            EditorGUILayout.BeginVertical("box");
            
            dataCible.speed = EditorGUILayout.FloatField("Speed", dataCible.speed);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("-0.01")) dataCible.speed -= 0.01f;
            if (GUILayout.Button("+0.01")) dataCible.speed += 0.01f;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(dataCible);
                AssetDatabase.SaveAssets();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Glisse un ScriptableObject 'Speed data' chef", MessageType.Info);
        }
    }
    
    private void OnEnable()
    {
        Prefill();
    }
    
    private void Prefill()
    {
        string[] guids = AssetDatabase.FindAssets("t:EntityParameters");

        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            dataCible = AssetDatabase.LoadAssetAtPath<EntityParameters>(path);
        }
    }
}