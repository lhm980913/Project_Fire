using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapEditor))]
public class MapEditorEditor : Editor
{
    private MapEditor mapEditor;

    private void Awake()
    {
        mapEditor = (MapEditor)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("生成Mesh"))
        {
            mapEditor.GenerateMesh();
        }
    }

    private void OnSceneGUI()
    {
        Vector3 pos = mapEditor.transform.position;
        EditorGUI.BeginChangeCheck();
        Handles.color = Color.yellow;
        Handles.DrawWireCube(pos, new Vector3(mapEditor.Width, mapEditor.Height, 0.0f));
        
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "MoveEdge");
        }
    }

    
}
