using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Dead : Enemy_Base_Stage
{
    enemy_bird enemy;
    float count;
    public Bird_Dead(enemy_bird ee)
    {

        enemy = ee;
    }

    public override void Enter()
    {
        count = 2.5f;
    }
    public override void Update()
    {
        count -= Time.deltaTime;
        if(count<0)
        {
            enemy.destroyself();
        }
    }

    public override void Check()
    {

    }
}
