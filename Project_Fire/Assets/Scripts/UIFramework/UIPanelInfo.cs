using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIBaseType PanelType;
    public string panelType;
    public string path;

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        UIBaseType temp = (UIBaseType)System.Enum.Parse(typeof(UIBaseType), panelType);
        PanelType = temp;
    }
}


