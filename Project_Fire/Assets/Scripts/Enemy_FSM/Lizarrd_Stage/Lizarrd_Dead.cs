using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Dead : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    public Lizarrd_Dead(enemy_lizarrd_new ee)
    {
        enemy = ee;
    }

    public override void Enter()
    {
        enemy.anim.CrossFade("lizarrd_dead", 0.2f);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Check()
    {
        base.Check();
    }
}
