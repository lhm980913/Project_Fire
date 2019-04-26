using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiHuo : Rune
{
    public JiHuo(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnManaFull;
        this.name = "激活";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log(ToString());
    }
}
