using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RuneInfo
{
    public string Name;
    public string IconPath;
    public string PrefabPath;
}

public class RunePrefab
{
    public Sprite Icon;
    public GameObject Prefab;

    public RunePrefab(RuneInfo info)
    {
        Icon = Resources.Load<Sprite>(info.IconPath);
        Prefab = Resources.Load<GameObject>(info.PrefabPath);
    }
}