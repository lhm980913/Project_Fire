using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Jatt : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Jatt(enemy_boss ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 1.2f;
        enemy.anim.CrossFade("boss_2", 0.2f);
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


