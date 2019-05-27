using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Dead : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    float count;
    public Lizarrd_Dead(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 2.5f;
        enemy.anim.CrossFade("lizarrd_dead", 0.2f);
        enemy.wudi11 = true;
        enemy.beattforce = 20;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if(count<0)
        {
            enemy.destroyself();
        }
       
    }

    public override void Check()
    {
        base.Check();
    }
}
