using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EffectConfigGenerator : EditorWindow
{
    static EffectConfigGenerator instance;
    [MenuItem("Window/CreateEffectConfig")]
    static void Init()
    {
        instance = (EffectConfigGenerator)EditorWindow.GetWindow(typeof(EffectConfigGenerator), true, "EffectConfigGenerator",false);
        instance.Show();
    }
    
    private void OnGUI()
    {
        if(GUILayout.Button("Begin"))
        {
            List<string> names = new List<string>();
            List<string> path = new List<string>();
            DirectoryInfo directory = new DirectoryInfo("Assets/Resources/Effect");
            FileInfo[] files = directory.GetFiles("*prefab");
            string lastName = ".prefab";
            //string firstName = "C:\\Users\\60294\\Documents\\Project_Fire\\Project_Fire\\Assets\\Resources\\";

            foreach (FileInfo file in files)
            {
                string trueName = file.Name.Substring(0, file.Name.Length - lastName.Length);
                names.Add(trueName);

                path.Add("Effect\\" + trueName);
            }

            EffectConfig effectConfig = (EffectConfig)ScriptableObject.CreateInstance(typeof(EffectConfig));
            effectConfig.CreateConfig(names, path);
            AssetDatabase.CreateAsset(effectConfig, "Assets/Resources/Config/EffectConfig.asset");
            
        }
    }
}
#endif