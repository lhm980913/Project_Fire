using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Dead : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Dead(enemy_lancer ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 5f;
        enemy.anim.CrossFade("dead", 0.2f);
        enemy.weapon.stage = 0;
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
