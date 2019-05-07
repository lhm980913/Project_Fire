using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Hurt : Enemy_Base_Stage
{
    enemy_assassin enemy;
    float count;
    public Assassin_Hurt(enemy_assassin ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = enemy.yingzhi_time;

        enemy.anim.CrossFade("", 0.1f);
        enemy.hurt_count = enemy.hurt_yuzhi;

    }
    public override void Update()
    {
        count -= Time.deltaTime;

        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.assassin_walk_stage);
        }

    }

    public override void Check()
    {

    }
}
