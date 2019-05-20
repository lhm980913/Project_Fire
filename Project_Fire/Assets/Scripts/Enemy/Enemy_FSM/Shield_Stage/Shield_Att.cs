using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Att : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Att(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1.8f, 2.2f);
        enemy.anim.CrossFade("att", 0.2f);
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
