﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Dead : Enemy_Base_Stage
{
    enemy_fire enemy;
    float count;
    public Fire_Dead(enemy_fire ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        SceneSystem.instance.Delete(enemy);
        count = 2.5f;
        enemy.anim.CrossFade("dead", 0.2f);
        enemy.wudi11 = true;
        enemy.beattforce = 20;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if (count < 0)
        {
            enemy.destroyself();
            
        }

    }

    public override void Check()
    {
        base.Check();
    }
}
