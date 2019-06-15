using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OK
public class XianDan : Rune
{
    testplayer player;
    public XianDan(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        this.name = "XianDan";
        RuneName = "霰弹";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        MpNeed = 40;
        player = testplayer.Instance;
        Description = "向前方一定区域发射致命的散弹";
    }
    public override void Execute()
    {
        Collider[] colliders;
        if (!player)
        {
            player = testplayer.Instance;
        }
        colliders = Physics.OverlapBox(player.transform.position + Vector3.right * testplayer.Instance.face_to * 4.0f * 0.6f, new Vector3(4.0f, 1.0f, 1.0f), Quaternion.identity, 1 << 11);
        foreach (var collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                testplayer.Instance.StartCoroutine(Exe(collider.gameObject));
            }
        }
    }

    private IEnumerator Exe(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        if(gameObject!=null && gameObject.GetComponent<enemy_base>())
        ProcessSystem.Instance.FPlayerSkill_Enemy(gameObject.GetComponent<enemy_base>(),1.7f);
    }
}
