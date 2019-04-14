using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Stand : Enemy_Base_Stage
{
    enemy_bird enemy;
    float count;
    public Bird_Stand(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.faceto *= -1;
            enemy.enemy.SetStage(enemy.bird_move_stage);
        }
    }
}
