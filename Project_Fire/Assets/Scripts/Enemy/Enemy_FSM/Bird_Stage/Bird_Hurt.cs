using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Hurt : Enemy_Base_Stage
{
    enemy_bird enemy;
    float count;

    public Bird_Hurt(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 0.8f;
        Debug.Log("打到鸟");
        enemy.hurt_count = enemy.hurt_yuzhi;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if(count<0)
        {
            enemy.enemy.SetStage(enemy.bird_stand_stage);
        }
        
    }

    public override void Check()
    {

    }
}
