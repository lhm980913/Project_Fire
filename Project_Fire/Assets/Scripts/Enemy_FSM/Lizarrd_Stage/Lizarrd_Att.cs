using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Att : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    float count;
    public Lizarrd_Att(enemy_lizarrd_new ee)
    {
        
        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1.7f, 2.2f);
        enemy.anim.CrossFade("lizarrd_att", 0.2f);
    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if(count<0)
        {
            enemy.enemy.SetStage(enemy.lizarrd_walk_stage);
        }
    }
}
