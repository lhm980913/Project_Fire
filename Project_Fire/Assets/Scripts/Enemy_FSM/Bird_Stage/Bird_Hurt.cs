using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Hurt : Enemy_Base_Stage
{
    enemy_bird enemy;

    public Bird_Hurt(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        Debug.Log("打到鸟");
        enemy.hurt_count = enemy.hurt_yuzhi;
    }
    public override void Update()
    {
        enemy.enemy.SetStage(enemy.bird_att_stage);
    }

    public override void Check()
    {

    }
}
