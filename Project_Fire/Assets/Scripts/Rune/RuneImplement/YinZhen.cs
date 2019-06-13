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
        RuneName = "银针";
        name = "YinZhen";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
        MpNeed = 10;
        Pin = testplayer.Instance.Pin;
    }
    public override void Execute()
    {
        if (!player)
        {
            player = testplayer.Instance;
        }
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.YinZhen);
        UnityEngine.Object.Instantiate(Pin, player.transform.position + player.face_to * player.transform.right * 1.0f, Quaternion.identity);
    }
}