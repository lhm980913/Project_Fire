using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Hurt : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Hurt(enemy_lancer ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = enemy.yingzhi_time;

        enemy.anim.CrossFade("hurt", 0.1f);
        enemy.hurt_count = Random.Range(enemy.hurt_yuzhi - 0.15f, enemy.hurt_yuzhi + 0.15f);

    }
    public override void Update()
    {
        count -= Time.deltaTime;

        if (count < 0)
        {
            enemy.FFaceToPlayer();
            enemy.enemy.SetStage(enemy.lancer_walk_stage);
        }

    }

    public override void Check()
    {

    }
}
