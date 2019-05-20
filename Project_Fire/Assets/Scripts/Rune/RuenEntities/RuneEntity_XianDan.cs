using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity_XianDan : RuneEntity
{
    void Awake()
    {
        rune = new XianDan(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        PanelOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PanelOff(other);
    }
}