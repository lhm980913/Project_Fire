using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Walk : Enemy_Base_Stage
{
    enemy_assassin enemy;
    public Assassin_Walk(enemy_assassin ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        enemy.anim.CrossFade("", 0.2f);
    }
    public override void Update()
    {
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.assassin_stand_stage);
        }
        //if (enemy.FSeePlayer())
        //{
        //    enemy.enemy.SetStage(enemy.assassin_run_stage);

        //}
        else if (enemy.FAttPlayer())
        {
            enemy.enemy.SetStage(enemy.assassin_att_stage);
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }
    }
}
