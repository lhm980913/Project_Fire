using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Walk : Enemy_Base_Stage
{
    enemy_fire enemy;
    public Fire_Walk(enemy_fire ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        enemy.anim.CrossFade("walk", 0.2f);

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



        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.fire_stand_stage);
        }

        if (enemy.FAttPlayer())
        {
          
                enemy.enemy.SetStage(enemy.fire_att_stage);
              
            
            
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }
        else if (enemy.FSeePlayer())
        {
            if (enemy.attcd < 0)
            {
                enemy.enemy.SetStage(enemy.fire_throw_stage);
                enemy.attcd = 7;

            }
            
            ////anim.SetTrigger("att");
            //anim.CrossFade("lizarrd_att", 0.2f);
        }
    }

    public override void Check()
    {
       
    }
}
