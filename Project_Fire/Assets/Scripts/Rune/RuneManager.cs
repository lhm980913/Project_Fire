using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RuneEvent
{
    ActiveOne,
    ActiveTwo,
    OnAttack,
    OnDefence,
    OnFlash,
    OnAttackFlyItem,
    OnManaFull,
    OnPickRune
}

public class RuneManager : MonoBehaviour
{
    private static RuneManager instance;
    public static RuneManager Instance
    {
        get
        {
            return instance;
        }
    }
    Dictionary<string, RunePrefab> runePrefabs;
    Dictionary<RuneEvent, List<Rune>> RunesDictionary;
    Rune[] runes;

    public void AddRune(Rune rune, int index)
    {
        List<Rune> temp;
        if (RunesDictionary == null)
        {
            Debug.Log("SDSD");
        }
        if(rune == null)
        {
            Debug.Log("Rune");
        }
        if (!RunesDictionary.TryGetValue(rune.runeEvent, out temp))
        {
            RunesDictionary.Add(rune.runeEvent, new List<Rune>());
            RunesDictionary.TryGetValue(rune.runeEvent, out temp);
        }
        temp.Add(rune);
        
        runes[index] = rune;
        string all = " ";
        foreach (var item in temp)
        {
            all += item.RuneName + " ";
        }
    }

    public void DeleteRune(Rune rune, int index)
    {
        List<Rune> temp;
        if(rune == null)
        {
            return;
        }
        if (!RunesDictionary.TryGetValue(rune.runeEvent, out temp))
            return;
        if (!temp.Remove(rune))
            Debug.Log("There is no such rune " + rune.ToString());
        runes[index] = null;

        string all = " ";
        foreach (var item in temp)
        {
            all += item.RuneName + " ";
        }
        Debug.Log(rune.runeEvent + " Delete " + all);
    }

    public void DebugRunes()
    {
        foreach (var item in runes)
        {
            Debug.Log(item.Name + " " + item.runeEvent + "\n");
        }
    }

    public void UseRune(RuneEvent runeEvent)
    {
        List<Rune> tempRunes;
        if (!RunesDictionary.TryGetValue(runeEvent, out tempRunes))
            return;
        foreach (var rune in tempRunes)
        {
            if(rune.runeType == RuneType.active)
            {
                if (testplayer.Instance.FLoseMana(rune.MpNeed))
                {
                    rune.Execute();
                }
            }
            else
            {
                rune.Execute();
            }
        }
    }

    public bool PickUpRune(Rune rune)
    {
        
        if(rune.runeType == RuneType.passive)
        {
            //for (int index = 0; index < runes.Length; index++)
            //{
            //    if (runes[index] == null)
            //    {
            //        AddRune(rune,index);
            //        return true;
            //    }
            //}
            for(int index = 2;index < 4; index++)
            {
                if(runes[index] == null)
                {
                    AddRune(rune, index);
                    return true;
                }
            }
            for(int index = 0;index < 2; index++)
            {
                if(runes[index] == null)
                {
                    AddRune(rune, index);
                    return true;
                }
            }
        }
        else
        {
            for (int index = 0; index < 2; index++)
            {

                if (runes[index] == null)
                {
                    rune.SetActiveEvent(index);
                    AddRune(rune, index);
                    return true;
                }
            }
            //int count = 0;
            //int spaceIndex = 0;
            //for (int index = 0; index < runes.Length; index++)
            //{
            //    if (runes[index] == null)
            //    {
            //        spaceIndex = index;
            //        break;
            //    }
            //    if (runes[index].runeType == RuneType.active)
            //    {
            //        count++;
            //    }
            //}
            //if (count < 2)
            //{
            //    rune.SetActiveEvent(count);
            //    AddRune(rune, spaceIndex);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        return false;
    }

    public bool TryGetIcon(Rune rune, out Sprite sprite)
    {
        RunePrefab temp;
        if(rune == null)
        {
            sprite = null;
            return false;
        }
        if(runePrefabs.TryGetValue(rune.Name,out temp))
        {
            sprite = temp.Icon;
            return true;
        }
        else
        {
            sprite = null;
            return false;
        }
    }

    [Serializable]
    private class RuneInfoList
    {
        public List<RuneInfo> infos;
    }

    private void InitRunePathDictionary()
    {
        TextAsset ta = Resources.Load("RunePathInfo") as TextAsset;
        RuneInfoList infoList = JsonUtility.FromJson<RuneInfoList>(ta.text);
        for(int index = 0; index < infoList.infos.Count; index++)
        {
            RuneInfo info = infoList.infos[index];
            RunePrefab runePrefab = new RunePrefab(info);
            runePrefabs.Add(info.Name, runePrefab);
        }
    }

    public Rune GetRune(int index)
    {
        return runes[index];
    }

    public bool TryGetRune(int index, out Rune rune)
    {
        if (runes[index] == null)
        {
            rune = null;
            return false;
        }
        else
        {
            rune = runes[index];
            return true;
        }
    }

    private void Awake()
    {
        instance = this;
        runes = new Rune[4];
        RunesDictionary = new Dictionary<RuneEvent, List<Rune>>();
        runePrefabs = new Dictionary<string, RunePrefab>();
        InitRunePathDictionary();
    }
}