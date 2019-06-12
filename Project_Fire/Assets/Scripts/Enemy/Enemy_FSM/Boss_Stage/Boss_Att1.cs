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
        count = 1.5f;
        enemy.anim.CrossFade("boss_3", 0.1f);
        enemy.ATK = 20;
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.boss_stand_stage);
        }
    }

    public override void Check()
    {
       
    }
}
