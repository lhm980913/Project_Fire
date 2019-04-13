using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Run : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    public Lizarrd_Run(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed *2.5f* Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.lizarrd_stand_stage);
        }
        if (!enemy.FSeePlayer())
        {
            enemy.enemy.SetStage(enemy.lizarrd_walk_stage);

        }
        else if (enemy.FAttPlayer())
        {
            enemy.enemy.SetStage(enemy.lizarrd_att_stage);
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }


    }

    





}
