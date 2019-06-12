using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Hurt : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Hurt(enemy_boss ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = enemy.yingzhi_time;

        enemy.anim.CrossFade("boss_strike", 0.1f);
        enemy.hurt_count = Random.Range(enemy.hurt_yuzhi - 0.15f, enemy.hurt_yuzhi + 0.15f);

    }
    public override void Update()
    {
        count -= Time.deltaTime;

        if (count < 0)
        {
            enemy.FFaceToPlayer();
            enemy.enemy.SetStage(enemy.boss_stand_stage);
        }

    }

    public override void Check()
    {

    }
}
