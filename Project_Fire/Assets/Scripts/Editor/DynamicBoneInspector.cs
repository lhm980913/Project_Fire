using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicBone))]
public class DynamicParticleInspector : Editor
{
    DynamicBone bone = null;
    private void OnEnable()
    {
        bone = (DynamicBone)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("UpdateData"))
        {
            bone.UpdateData();
        }
    }
}
