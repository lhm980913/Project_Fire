using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Hurt : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    float count;
    public Lizarrd_Hurt(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(0.6f, 1f);

        enemy.anim.CrossFade("lizarrd_hurt", 0.1f);
        enemy.hurt_count = enemy.hurt_yuzhi;

    }
    public override void Update()
    {
        count -= Time.deltaTime;

        if(count<0)
        {
            enemy.enemy.SetStage(enemy.lizarrd_walk_stage);
        }
        
    }

    public override void Check()
    {
        
    }
}
