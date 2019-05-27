using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Throw : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Throw(enemy_lancer ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 1.1f;
        enemy.anim.CrossFade("throw1", 0.2f);
        enemy.weapon.stage = 2;
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
            if(Random.Range(0,3)==0)
            {
                enemy.enemy.SetStage(enemy.lancer_throw1_stage);
            }
            else
            {
               
                enemy.enemy.SetStage(enemy.lancer_walk_stage);
            }
           


        }

    }

}
