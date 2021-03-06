﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Att : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Att(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1.5f, 1.8f);
        enemy.anim.CrossFade("att", 0.2f);
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if(count < 0.7f)
        {
            if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && enemy.fighting && testplayer.Instance.grounded)
            {
                enemy.enemy.SetStage(enemy.shield_def_stage);
            }
            if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && enemy.fighting && !testplayer.Instance.grounded)
            {
                if (Vector3.Distance(testplayer.Instance.transform.position, enemy.transform.position) < 3)
                {
                    enemy.enemy.SetStage(enemy.shield_back_stage);
                }
            }
        }
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.shield_walk_stage);
        }
    }
}
