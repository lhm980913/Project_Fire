using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Def : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Def(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = Random.Range(1f, 1.5f);
        enemy.anim.CrossFade("def", 0.2f);
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && enemy.fighting && !testplayer.Instance.grounded)
        {
            if (Vector3.Distance(testplayer.Instance.transform.position, enemy.transform.position) < 3)
            {
                enemy.enemy.SetStage(enemy.shield_back_stage);
            }
        }
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.enemy.SetStage(enemy.shield_walk_stage);
        }
    }
}
