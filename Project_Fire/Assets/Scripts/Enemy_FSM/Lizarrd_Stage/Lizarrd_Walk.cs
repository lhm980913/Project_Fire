using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Walk : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    public Lizarrd_Walk(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        enemy.anim.CrossFade("lizarrd_walk",0.2f);
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        //if (enemy.fighting&&Vector3.Distance(enemy.transform.position,testplayer.Instance.transform.position)<5)
        //{
        //    enemy.FFaceToPlayer();
        //}
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.lizarrd_stand_stage);
        }
        if (enemy.FSeePlayer())
        {
            enemy.enemy.SetStage(enemy.lizarrd_run_stage);

        }
        else if (enemy.FAttPlayer())
        {
            enemy.enemy.SetStage(enemy.lizarrd_att_stage);
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }
    }
}
