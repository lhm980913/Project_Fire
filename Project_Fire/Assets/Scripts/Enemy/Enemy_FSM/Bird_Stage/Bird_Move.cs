using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Move : Enemy_Base_Stage
{
    enemy_bird enemy;

    public Bird_Move(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {

    }
    public override void Update()
    {
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.bird_stand_stage);
        }
        if (enemy.FSeePlayer())
        {
            enemy.enemy.SetStage(enemy.bird_att_stage);

        }
        
    }
}
