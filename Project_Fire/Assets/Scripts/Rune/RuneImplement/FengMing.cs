using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FengMing : Rune
{
    public FengMing(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnPickRune;
        this.name = "蜂鸣";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
