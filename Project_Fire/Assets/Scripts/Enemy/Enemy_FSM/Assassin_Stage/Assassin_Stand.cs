using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Stand : Enemy_Base_Stage
{
    enemy_assassin enemy;
    float count;
    public Assassin_Stand(enemy_assassin ee)
    {
        enemy = ee;

    }

    public override void Enter()
    {
        count = Random.Range(0.5f, 1f);
        enemy.anim.CrossFade("stand", 0.2f);
        //enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * 2.5f * Time.deltaTime, Space.Self);

    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if (enemy.FSeePlayer())
        {

            enemy.faceto *= -1;
            enemy.assassin1.material = enemy.assassin_mar;
            enemy.assassin2.material = enemy.assassin_mar;
            enemy.enemy.SetStage(enemy.assassin_walk_stage);
        }
    }
}
