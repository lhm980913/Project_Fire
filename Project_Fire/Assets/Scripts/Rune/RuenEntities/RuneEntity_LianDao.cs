using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity_LianDao : RuneEntity
{
    void Awake()
    {
        rune = new LianDao(this);
    }

    private void OnTriggerStay(Collider other)
    {
        PanelOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PanelOff(other);
    }
}
