using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Start : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Start(enemy_lancer ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2;
        enemy.anim.CrossFade("chaofeng", 0.2f);

    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.lancer_stand_stage);
        }
    }
}
