using Config;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(EffectConfig))]
public class EffectConfigEditor : Editor
{
    EffectConfig effectConfig;
    private void OnEnable()
    {
        effectConfig = (EffectConfig)target;
    }
    public override void OnInspectorGUI()
    {
        for(int i = 0; i < effectConfig.keys.Count; i++)
        {
            EditorGUILayout.LabelField(effectConfig.keys[i]);
            EditorGUILayout.LabelField(effectConfig.values[i]);
            EditorGUILayout.IntField("Amount", effectConfig.Num[i]);
            EditorGUILayout.Space();
        }
    }
}
#endif