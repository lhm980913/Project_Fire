using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity_TuXi : RuneEntity
{
    void Awake()
    {
        rune = new TuXi(this);
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
