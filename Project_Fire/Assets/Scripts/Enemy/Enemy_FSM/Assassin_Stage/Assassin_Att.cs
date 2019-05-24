﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Att : Enemy_Base_Stage
{
    enemy_assassin enemy;
    float count;
    public Assassin_Att(enemy_assassin ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2f;
        if(enemy.skillcound < 0)
        {
            enemy.anim.CrossFade("extraatt", 0.2f);
            enemy.skillcound = enemy.skillcd;
        }
      
 
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.assassin_walk_stage);
        }
    }
}
