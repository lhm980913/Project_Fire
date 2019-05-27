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
        enemy.anim.CrossFade("walk", 0.2f);
        enemy.FFaceToPlayer();
    }
    public override void Update()
    {
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (enemy.FCheckFilp())
        {
            enemy.faceto*=-1;
        }
        //if (enemy.FSeePlayer())
        //{
        //    enemy.enemy.SetStage(enemy.assassin_run_stage);

        //}
        if(enemy.FAttPlayer())
        {
            enemy.enemy.SetStage(enemy.assassin_att2_stage);
        }
        else if (enemy.fighting&& enemy.skillcound < 0)
        {
            enemy.enemy.SetStage(enemy.assassin_att_stage);
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }
    }
}
