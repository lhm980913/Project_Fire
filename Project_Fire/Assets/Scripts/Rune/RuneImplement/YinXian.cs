using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OK
public class YinXian : Rune
{
    int Damage;
    testplayer player;
    public YinXian(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        RuneName = "银线";
        name = "YinXian";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        MpNeed = 10;
        Damage = 4;
        player = testplayer.Instance;
    }

    public override void Execute()
    {
        Collider[] colliders;
        if (!player)
        {
            player = testplayer.Instance;
        }
        colliders = Physics.OverlapBox(player.transform.position, new Vector3(100, 1, 1), Quaternion.identity, 1 << 11);
        enemy_base[] enemys = new enemy_base[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            enemys[i] = colliders[i].GetComponent<enemy_base>();
            ProcessSystem.Instance.FPlayerSkill_Enemy(enemys[i]);
        }
        RuneManager.Instance.StartCoroutine(buffer(enemys));
    }

    public IEnumerator<YieldInstruction> buffer(enemy_base[] enemys)
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (var enemy in enemys)
            {
                ProcessSystem.Instance.FPlayerSkill_Enemy(enemys[i]);
            }
            yield return new WaitForSeconds(0.25f);
        }

    }
}
