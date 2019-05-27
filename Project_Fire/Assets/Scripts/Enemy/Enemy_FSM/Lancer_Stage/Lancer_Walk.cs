using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Walk : Enemy_Base_Stage
{
    enemy_lancer enemy;
    public Lancer_Walk(enemy_lancer ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        enemy.anim.CrossFade("walk", 0.2f);

        //if (enemy.fighting)
        //{
        //    enemy.FFaceToPlayer();
        //}
    }
    public override void Update()
    {
       
        //if (enemy.fighting)
        //{
        //    enemy.FFaceToPlayer();
        //}
        if (enemy.FCheckFilp())
        {
            enemy.enemy.SetStage(enemy.lancer_stand_stage);
        }
        //if (enemy.fighting&&Vector3.Distance(enemy.transform.position,testplayer.Instance.transform.position)<5)
        //{
        //    enemy.FFaceToPlayer();
        //}


        if (enemy.FSeePlayer()&&Random.Range(0,3)!=0)
        {
            if (enemy.attcd < 0)
            {
                if (enemy.weapon.stage == 1|| enemy.weapon.stage == 4)
                {
                    enemy.enemy.SetStage(enemy.lancer_throw_stage);
                }
                else
                {
                    enemy.enemy.SetStage(enemy.lancer_throw1_stage);
                }

                enemy.attcd = 5;

            }
        }
        else if (enemy.FAttPlayer())
        {
            if ((enemy.transform.position.x - testplayer.Instance.transform.position.x) *enemy.faceto > 0)
            {
                enemy.enemy.SetStage(enemy.lancer_exatt_stage);
                
            }
            else
            {
                if(Random.Range(0,3)!=1)
                {
                    enemy.enemy.SetStage(enemy.lancer_att_stage);
                }
                else
                {
                    enemy.enemy.SetStage(enemy.lancer_exatt_stage);
                }
               
            }
        }
        enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {

    }
}

