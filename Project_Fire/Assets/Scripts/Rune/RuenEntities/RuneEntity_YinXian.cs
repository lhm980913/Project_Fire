using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity_YinXian : RuneEntity
{
    void Awake()
    {
        rune = new YinXian(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        PanelOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PanelOff(other);
    }

    private void OnTriggerStay(Collider other)
    {
        PanelExecute(other);
    }
}