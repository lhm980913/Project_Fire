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
        if (count < 0)
        {

            enemy.enemy.SetStage(enemy.lancer_walk_stage);


        }

    }

}
