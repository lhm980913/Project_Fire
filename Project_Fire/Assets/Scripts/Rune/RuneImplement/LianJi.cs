using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianJi : Rune
{
    int count = 0;
    public LianJi(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttack;
        RuneName = "连击";
        name = "LianJi";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        if(count < 4)
        {
            testplayer.Instance.LianJiEffect.Stop();
            testplayer.Instance.attlevel = 1;
            count++;
        }
        else
        {
            testplayer.Instance.LianJiEffect.Play();
            testplayer.Instance.attlevel = 2;
            count = 0;
        }
    }
}
