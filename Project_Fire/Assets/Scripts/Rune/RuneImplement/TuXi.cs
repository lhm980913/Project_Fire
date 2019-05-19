using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OK
public class TuXi : Rune
{
    testplayer player;
    public TuXi(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnDefence;
        this.name = "吐息";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
    }
    public override void Execute()
    {
        testplayer.Instance.FGetMana(testplayer.Instance.GotMana * 2.0f);
    }
}