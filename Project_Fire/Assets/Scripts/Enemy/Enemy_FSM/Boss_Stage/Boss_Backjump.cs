using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Backjump : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Backjump(enemy_boss ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 1.7f;
        enemy.anim.CrossFade("boss_6", 0.2f);
        enemy.ATK = 20;
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.boss_stand_stage);
        }
    }
}
