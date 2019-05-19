using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiHuo : Rune
{
    private float AttackLevel = 1.25f;
    private float SpeedLevel = 1.25f;
    public JiHuo(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.OnManaFull;
        RuneName = "激活";
        name = "JiHuo";
        rune_Type = RuneType.passive;
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        if (testplayer.Instance.mana == testplayer.Instance.Manamax)
        {
            testplayer.Instance.player_attack *= AttackLevel;
            testplayer.Instance.speed *= SpeedLevel;
        }
        else
        {
            testplayer.Instance.player_attack /= AttackLevel;
            testplayer.Instance.speed /= SpeedLevel;
        }
        
    }
}
