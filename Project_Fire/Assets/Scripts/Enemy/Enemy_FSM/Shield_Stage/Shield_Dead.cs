using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Dead : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Dead(enemy_shield ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 2.5f;
        enemy.anim.CrossFade("dead", 0.2f);
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
