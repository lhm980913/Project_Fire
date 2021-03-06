﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Stage : Player_Base_Stage
{
    float jumpcount;
    public Jump_Stage()
    {
        
    }

    public void Enter()
    {
        //testplayer.Instance.canflash = true;
        //Debug.Log("jump");
        //jumpcount = 0.25f;
        testplayer.Instance.anim.CrossFade("player_jump_on", 0.1f);
    }

    public void Input()
    {
        //if (Player_Controller_System.Instance.Button_A == Player_Controller_System.Button_Stage.down)
        //{
        //    Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.jump_speed);
        //    testplayer._player.SetStage(testplayer.Instance.jump_stage);
        //}
        if (Player_Controller_System.Instance.Button_A == Player_Controller_System.Button_Stage.down && testplayer.Instance.doublejump)
        {
            Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.doublejump_speed);
            testplayer.Instance.doublejump = false;
            testplayer._player.SetStage(testplayer.Instance.doublejump_stage);
        }
        if (testplayer.Instance.grounded)
        {
            
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
        if (testplayer.Instance.flashcd < 0 && Player_Controller_System.Instance.Button_RB == Player_Controller_System.Button_Stage.down && testplayer.Instance.canflash ==true)
        {
            testplayer.Instance.canflash = false;
            testplayer._player.SetStage(testplayer.Instance.flash_stage);
        }
        if (Player_Controller_System.Instance.Button_LB == Player_Controller_System.Button_Stage.down  && testplayer.Instance.canrape)
        {
            testplayer._player.SetStage(testplayer.Instance.rape_stage);
        }
        if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down&&testplayer.Instance.canatt)
        {
           
                testplayer._player.SetStage(testplayer.Instance.att_stage);
            

        }

        if (Player_Controller_System.Instance.LTDown && RuneManager.Instance.TryGetRune(0, out Rune Rune1))
        {

            if (testplayer.Instance.mana > Rune1.MpNeed)
            {
                testplayer.Instance.skillid = 1;
                testplayer._player.SetStage(testplayer.Instance.initiative_stage);
            }

        }
        if (Player_Controller_System.Instance.RTDown && RuneManager.Instance.TryGetRune(1, out Rune Rune2))
        {
            if (testplayer.Instance.mana > Rune2.MpNeed)
            {
                testplayer.Instance.skillid = 2;
                testplayer._player.SetStage(testplayer.Instance.initiative_stage);
            }

        }

    }

    public void Update_()
    {
       
        //if (Player_Controller_System.Instance.Horizontal_Left != 0)
        //{
            Player_Function.FWalk(testplayer.Instance.playergameobj, Player_Controller_System.Instance, testplayer.Instance.speed* testplayer.Instance.jumpmovespeed);
        //}
        //if (Player_Controller_System.Instance.Button_A == Player_Controller_System.Button_Stage.stay || Player_Controller_System.Instance.Button_A == Player_Controller_System.Button_Stage.down)
        //{
        //    if (testplayer.Instance.canjump == true)
        //    {
        //        jumpcount -= Time.deltaTime;
        //        testplayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.up * testplayer.Instance.jump_speed + new Vector3(testplayer.Instance.GetComponent<Rigidbody>().velocity.x, 0, 0);
        //        if(jumpcount<0)
        //        {
        //            testplayer.Instance.canjump = false;
        //        }
        //    }
        //}
        //else
        //{
        //    testplayer.Instance.canjump = false;
        //}




        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 30 * Time.deltaTime; //zhongli
        Player_Function.FFace_to();
    }
}
