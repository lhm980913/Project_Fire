using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Dead : Enemy_Base_Stage
{
    enemy_assassin enemy;
    float count;
    public Assassin_Dead(enemy_assassin ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        count = 2.5f;
        enemy.anim.CrossFade("", 0.2f);
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
