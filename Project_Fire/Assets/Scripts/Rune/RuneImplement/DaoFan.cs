using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaoFan : Rune
{
    public DaoFan(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttackFlyItem;
        this.name = "刀反";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
