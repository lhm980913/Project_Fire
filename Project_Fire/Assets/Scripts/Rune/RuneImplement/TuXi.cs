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
        RuneName = "吐息";
        name = "TuXi";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
        Description = "招架成功后获得大量能量";
    }
    public override void Execute()
    {
        testplayer.Instance.FGetMana(testplayer.Instance.GotMana * 2.0f);
    }
}