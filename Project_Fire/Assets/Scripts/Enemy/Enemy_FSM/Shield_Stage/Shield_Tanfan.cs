using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Tanfan : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Tanfan(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        testplayer.Instance.hurtforce = 12;
        count = Random.Range(1.1f, 1.4f);
        enemy.anim.CrossFade("light_att", 0.2f);
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
        if (count < 0.35f)
        {
            if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && enemy.fighting && testplayer.Instance.grounded)
            {
                
                enemy.enemy.SetStage(enemy.shield_def_stage);
            }
            if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && enemy.fighting && !testplayer.Instance.grounded)
            {
                if (Vector3.Distance(testplayer.Instance.transform.position, enemy.transform.position) < 3)
                {
                   
                    enemy.enemy.SetStage(enemy.shield_back_stage);
                }
            }
        }
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.shield_walk_stage);
        }
    }
}
