using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Config
{
    public class EffectConfig : ScriptableObjectDictionary<string, string>
    {
        public List<int> Num = new List<int>();
        public void CreateConfig(List<string> name,List<string> path)
        {
            for(int i = 0;i<name.Count;i++)
            {
                keys.Add(name[i]);
                values.Add(path[i]);
                Num.Add(1);
                target.Add(keys[i], values[i]);
            }
        }
    }
    
}