using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OK
public class TuXi : Rune
{
    testplayer player;
    float gotMana;
    public TuXi(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnDefence;
        this.name = "吐息";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
        gotMana = 10;
    }
    public override void Execute()
    {
        testplayer.Instance.FGetMana(gotMana);
    }
}