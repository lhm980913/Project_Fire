using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Att : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Att(enemy_lancer ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1.8f, 2.2f);
        enemy.anim.CrossFade("att1", 0.2f);
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
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.lancer_walk_stage);
        }
    }
}
