using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity_YinZhen : RuneEntity
{
    void Awake()
    {
        rune = new YinZhen(this);
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