using System.Collections;
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
        count = 1.3f;
        enemy.anim.CrossFade("", 0.2f);
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
