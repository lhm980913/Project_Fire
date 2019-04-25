using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XinYan : Rune
{
    testplayer player;
    public XinYan(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnDefence;
        this.name = "心眼";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
    }
    public override void Execute()
    {

    }
}