using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Throw1 : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Throw1(enemy_lancer ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count =2f;
        enemy.anim.CrossFade("throw2", 0.2f);
     
        
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
