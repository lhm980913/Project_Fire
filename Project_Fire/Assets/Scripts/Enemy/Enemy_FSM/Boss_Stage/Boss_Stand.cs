using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stand : Enemy_Base_Stage
{
    enemy_boss enemy;
    float count;
    public Boss_Stand(enemy_boss ee)
    {
        enemy = ee;

    }

    public override void Enter()
    {

        count = enemy.yingzhi;
        enemy.anim.CrossFade("boss_stand 1", 0.2f);
        //enemy.transform.Translate(enemy.transform.right * -enemy.faceto * enemy.movespeed * 2.5f * Time.deltaTime, Space.Self);
       
    }
    public override void Update()
    {
        count -= Time.deltaTime;

        if(enemy.fighting)
        {
            if (count < 0)
            {
                enemy.yingzhi = 0.4f;
                switch (enemy.switch_skill())
                {
                    case 1:
                        {
                            enemy.enemy.SetStage(enemy.boss_att1_stage);
                        }
                        break;
                    case 2:
                        {
                            enemy.enemy.SetStage(enemy.boss_att2_stage);
                        }
                        break;
                    case 3:
                        {
                            enemy.enemy.SetStage(enemy.boss_att3_stage);
                        }
                        break;
                    case 4:
                        {
                            enemy.enemy.SetStage(enemy.boss_gun_stage);
                        }
                        break;
                    case 5:
                        {
                            enemy.enemy.SetStage(enemy.boss_jatt_stage);
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }



                
            }







        }


       
        ////////////////////////
        ///判定代码 
        //////////////////////////
    }

    public override void Check()
    {
       
    }
}


