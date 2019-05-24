using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Att2 : Enemy_Base_Stage
{
    enemy_assassin enemy;
    float count;
    public Assassin_Att2(enemy_assassin ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2f;

        enemy.FFaceToPlayer();
            enemy.anim.CrossFade("att2", 0.2f);
            
        
       
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
