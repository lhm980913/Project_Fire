using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer_Exatt : Enemy_Base_Stage
{
    enemy_lancer enemy;
    float count;
    public Lancer_Exatt(enemy_lancer ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        testplayer.Instance.hurtforce = 20;
        count = 3.5f;
        enemy.anim.CrossFade("att3", 0.2f);
        enemy.ATK = 40;
        if (enemy.fighting&&Random.Range(0,2)==0)
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
            testplayer.Instance.hurtforce = 7;
            enemy.enemy.SetStage(enemy.lancer_walk_stage);
        }
    }
}
