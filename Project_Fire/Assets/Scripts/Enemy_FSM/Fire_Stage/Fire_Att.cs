using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Att : Enemy_Base_Stage
{
    enemy_fire enemy;
    float count;
    public Fire_Att(enemy_fire ee)
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
            enemy.enemy.SetStage(enemy.fire_walk_stage);
        }
    }
}
