using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinZhen : Rune
{
    GameObject Pin;
    testplayer player;
    public YinZhen(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        this.name = "银针";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
        Pin = (GameObject)Resources.Load("Prefab/Pin");
    }
    public override void Execute()
    {
        UnityEngine.Object.Instantiate(Pin, player.transform.position, Quaternion.identity);
    }
}