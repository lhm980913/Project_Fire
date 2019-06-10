using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Att1 : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Att1(enemy_boss ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2;
        enemy.anim.CrossFade("att1", 0.2f);
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
            if (enemy.FAttPlayer())
            {
                enemy.enemy.SetStage(enemy.boss_att1_stage);
            }
          
        }
    }
}
