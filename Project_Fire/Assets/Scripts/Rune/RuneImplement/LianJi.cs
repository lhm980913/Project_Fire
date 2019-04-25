using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianJi : Rune
{
    public LianJi(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttack;
        this.name = "连击";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
