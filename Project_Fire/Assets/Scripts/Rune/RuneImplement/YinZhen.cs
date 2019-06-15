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
        MpNeed = 20;
        if (testplayer.Instance != null)
        {
            player = testplayer.Instance;
            Pin = testplayer.Instance.Pin;
        }
        Description = "发射一根不致命的银针";
    }
    public override void Execute()
    {
        if (!player)
        {
            player = testplayer.Instance;
        }
        if (!Pin)
        {
            Pin = testplayer.Instance.Pin;
        }
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.YinZhen);
        UnityEngine.Object.Instantiate(Pin, player.transform.position + player.face_to * player.transform.right * 1.0f, Quaternion.identity);
    }

    public IEnumerator<YieldInstruction> DelayInit()
    {
        yield return new WaitForSeconds(0.2f);
        player = testplayer.Instance;
        Pin = testplayer.Instance.Pin;
    }
}