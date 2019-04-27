using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingZhun : Rune
{
    public JingZhun(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttackFlyItem;
        this.name = "JingZhun";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
