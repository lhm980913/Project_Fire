using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScriptableObjectDictionary<TKey, TValue> : ScriptableObject
{
    public List<TKey> keys = new List<TKey>();
    public List<TValue> values = new List<TValue>();
    protected Dictionary<TKey, TValue> target = new Dictionary<TKey, TValue>();
    public Dictionary<TKey, TValue> Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
            keys = new List<TKey>(Target.Keys);
            values = new List<TValue>(Target.Values);
        }
    }

}
