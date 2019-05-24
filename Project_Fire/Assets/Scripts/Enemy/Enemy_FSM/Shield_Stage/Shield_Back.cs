using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Back : Enemy_Base_Stage
{
    enemy_shield enemy;
    float count;
    public Shield_Back(enemy_shield ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 0.85f;
        enemy.anim.CrossFade("back", 0.2f);
        if (enemy.fighting)
        {
            enemy.FFaceToPlayer();
        }
        enemy.GetComponent<CapsuleCollider>().enabled = false;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        enemy.transform.Translate(enemy.transform.right * enemy.faceto * enemy.movespeed*2 * Time.deltaTime, Space.Self);
    }

    public override void Check()
    {
        if (count < 0)
        {
            enemy.GetComponent<CapsuleCollider>().enabled = true;
            enemy.enemy.SetStage(enemy.shield_walk_stage);
        }
    }
}
