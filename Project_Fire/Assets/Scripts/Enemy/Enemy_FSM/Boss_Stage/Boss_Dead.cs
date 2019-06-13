using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Dead : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Dead(enemy_boss ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        SceneSystem.instance.Delete(enemy);
        count = 2f;
        enemy.anim.CrossFade("boss_dead", 0.2f);

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
