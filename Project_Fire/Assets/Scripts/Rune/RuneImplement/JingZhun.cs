using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingZhun : Rune
{
    public JingZhun(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttackFlyItem;
        RuneName = "精准";
        name = "JingZhun";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
        Description = "击落子弹恢复能量";
    }
    public override void Execute()
    {
        testplayer.Instance.FGetMana(testplayer.Instance.GotMana * 2.0f);
    }
}
