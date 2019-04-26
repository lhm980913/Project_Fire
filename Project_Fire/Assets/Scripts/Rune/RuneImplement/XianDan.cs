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
        this.name = "霰弹";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
    }
    public override void Execute()
    {
        Collider[] colliders;
        colliders = Physics.OverlapBox(player.transform.position + Vector3.right * testplayer.Instance.face_to * 2.0f * 0.6f, new Vector3(2.0f, 1.0f, 1.0f), Quaternion.identity, 1 << 11);
        foreach (var collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                ProcessSystem.Instance.FPlayerSkill_Enemy(collider.gameObject.GetComponent<enemy_base>());
            }
        }
    }
}
