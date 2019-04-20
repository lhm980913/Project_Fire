using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Hurt : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    public Lizarrd_Hurt(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        Debug.Log(11);
        enemy.hurt_count = enemy.hurt_yuzhi;

    }
    public override void Update()
    {
        enemy.enemy.SetStage(enemy.lizarrd_walk_stage);
    }

    public override void Check()
    {
        
    }
}
