using UnityEngine;
using UnityEditor;

public class EntityEditorWindow : EditorWindow
{
    public EntityData dataCible;

    [MenuItem("Tools/PlayerModifier")]
    public static void ShowWindow()
    {
        GetWindow<EntityEditorWindow>("PlayerModifier");
    }

    private void OnGUI()
    {
        GUILayout.Label("Entity modifier", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        dataCible = (EntityData)EditorGUILayout.ObjectField("Entity to modify", dataCible, typeof(EntityData), false);

        if (dataCible != null)
        {
            EditorGUILayout.BeginVertical("box");
            
            dataCible.speed = EditorGUILayout.IntField("Speed", dataCible.speed);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("-10")) dataCible.speed -= 10;
            if (GUILayout.Button("+10")) dataCible.speed += 10;
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
        string[] guids = AssetDatabase.FindAssets("t:EntityData");

        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            dataCible = AssetDatabase.LoadAssetAtPath<EntityData>(path);
        }
    }
}