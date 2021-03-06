﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Stage : Player_Base_Stage
{
    float count;
    public Interaction_Stage()
    {

    }
    public void Enter()
    {
        count = 0.5f;
        testplayer.Instance.heal.SetActive(true);
    }

    public void Input()
    {
        if (Player_Controller_System.Instance.Button_B == Player_Controller_System.Button_Stage.up)
        {
            testplayer.Instance.heal.SetActive(false);
            var shape = testplayer.Instance.heal.GetComponent<ParticleSystem>().shape;
            shape.radius = 0.5f;
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
    }

    // Update is called once per frame
    public void Update_()
    {
        count -= Time.deltaTime;
        if (testplayer.Instance.mana <= 0 || testplayer.Instance.hp >= testplayer.Instance.Hpmax)
        {
            testplayer.Instance.heal.SetActive(false);
            var shape = testplayer.Instance.heal.GetComponent<ParticleSystem>().shape;
            shape.radius = 0.5f;
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
        if (count<0)
        {
            if(testplayer.Instance.mana > 0 && testplayer.Instance.hp < testplayer.Instance.Hpmax)
            {
                var shape = testplayer.Instance.heal.GetComponent<ParticleSystem>().shape;
                shape.radius = 1;
                testplayer.Instance.mana -= 50 * Time.deltaTime;
                testplayer.Instance.hp += 50 * Time.deltaTime;
                MainPanel.Instance.UpdateHp();
                MainPanel.Instance.UpdateMp();
            }
          
           
        }
       
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 30 * Time.deltaTime; //zhongli
    }
}