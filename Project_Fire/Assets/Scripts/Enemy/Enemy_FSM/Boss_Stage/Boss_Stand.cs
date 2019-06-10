﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stand : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Stand(enemy_boss ee)
    {
        enemy = ee;

    }

    public override void Enter()
    {

        count = 0.2f;
        enemy.anim.CrossFade("stand", 0.2f);
        //enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * 2.5f * Time.deltaTime, Space.Self);
        if (enemy.FCheckFilp())
        {
            enemy.faceto *= -1;
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;


        ////////////////////////
        ///判定代码 
        //////////////////////////
    }

    public override void Check()
    {
        if (count < 0)
        {


          //  enemy.enemy.SetStage(enemy.lancer_walk_stage);
        }
    }
}


