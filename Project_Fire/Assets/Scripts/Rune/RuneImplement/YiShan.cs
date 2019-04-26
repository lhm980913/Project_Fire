using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YiShan : Rune
{
    public YiShan(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnFlash;
        this.name = "一闪";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
