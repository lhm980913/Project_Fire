using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Def : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Def(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1.8f, 2.2f);
        enemy.anim.CrossFade("tanfan", 0.2f);
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
            enemy.enemy.SetStage(enemy.shield_walk_stage);
        }
    }
}
