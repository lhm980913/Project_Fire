using System;
using System.Collections.Generic;
using UnityEngine;

public enum RuneType
{
    passive,
    active
}

public abstract class Rune
{
    protected RuneEvent rune_Event;
    public RuneEvent runeEvent
    {
        get
        {
            return rune_Event;
        }
    }
    public RuneEntity runeEntity;
    protected RuneType rune_Type;
    public RuneType runeType
    {
        get
        {
            return rune_Type;
        }
    }
    protected string name;
    public string RuneName;
    public string Name
    {
        get
        {
            return name;
        }
    }
    public float MpNeed;
    public string Description;
    public Rune(RuneEntity runeEntity)
    {
        this.runeEntity = runeEntity;
    }
    public abstract void Execute();
    public void SetActiveEvent(int index)
    {
        if (rune_Event != RuneEvent.ActiveOne && rune_Event != RuneEvent.ActiveTwo)
        {
            return;
        }
        else
        {
            rune_Event = (RuneEvent)index;
        }
    }
}

public class testRune : Rune
{
    public testRune(RuneEntity runeEntity):base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttack;
        this.name = "Test";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log("TestRune");
    }
}









