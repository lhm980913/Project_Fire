using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Att : Enemy_Base_Stage
{
    enemy_bird enemy;
    float count;
    public Bird_Att(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 1.8f;
        // enemy.anim.CrossFade("lizarrd_att", 0.2f);
        Debug.Log("att");
        enemy.Fatt();
    }
    public override void Update()
    {
        count -= Time.deltaTime;
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.bird_move_stage);
        }
    }
}
