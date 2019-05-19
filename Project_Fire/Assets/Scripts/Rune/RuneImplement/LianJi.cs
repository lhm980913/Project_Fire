﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianJi : Rune
{
    int count = 0;
    public LianJi(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttack;
        this.name = "连击";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        if(count < 4)
        {
            testplayer.Instance.attlevel = 1;
            count++;
        }
        else
        {
            testplayer.Instance.attlevel = 2;
            count = 0;
        }
    }
}
