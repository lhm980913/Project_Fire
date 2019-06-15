using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianDao : Rune
{
    GameObject Sickle;
    testplayer player;
    public LianDao(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        this.name = "LianDao";
        RuneName = "飓风之镰";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        MpNeed = 30;
        Description = "向前方发射一斤旋转的镰刀";

        if (testplayer.Instance != null)
        {
            Sickle = testplayer.Instance.Sickle;
            player = testplayer.Instance;
        }
    }
    public override void Execute()
    {
        GameObject temp;
        if (player == null)
        {
            player = testplayer.Instance;
        }
        if(Sickle == null)
        {
            Sickle = testplayer.Instance.Sickle;
        }
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Sickle);
        temp = UnityEngine.Object.Instantiate(Sickle, player.transform.position, Quaternion.identity);
        temp.GetComponent<LianDaoEntity>().dir = testplayer.Instance.face_to * new Vector3(1, 0, 0);
    }

    IEnumerator<YieldInstruction> DelayInit()
    {
        yield return new WaitForSeconds(0.2f);
        Sickle = testplayer.Instance.Sickle;
        player = testplayer.Instance;
    }
}
