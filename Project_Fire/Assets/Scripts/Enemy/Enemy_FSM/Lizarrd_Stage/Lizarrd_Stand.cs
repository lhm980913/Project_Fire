using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizarrd_Stand : Enemy_Base_Stage
{
    enemy_lizarrd_new enemy;
    float count;
    public Lizarrd_Stand(enemy_lizarrd_new ee)
    {
        enemy = ee;
        
    }

    public override void Enter()
    {
        count = Random.Range(0.5f,1f);
        enemy.anim.CrossFade("lizarrd_stand1", 0.2f);
        //enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * 2.5f * Time.deltaTime, Space.Self);

    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if(count <0)
        {
            
            enemy.faceto *= -1;
            enemy.enemy.SetStage(enemy.lizarrd_walk_stage);
        }
    }
}
