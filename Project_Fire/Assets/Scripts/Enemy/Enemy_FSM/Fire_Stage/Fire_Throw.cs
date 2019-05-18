using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Throw : Enemy_Base_Stage
{
    enemy_fire enemy;
    float count;
    public Fire_Throw(enemy_fire ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 3;
        enemy.anim.CrossFade("throw", 0.2f);
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if(count<0)
        {

            enemy.enemy.SetStage(enemy.fire_walk_stage);
            
           
        }

    }

}
