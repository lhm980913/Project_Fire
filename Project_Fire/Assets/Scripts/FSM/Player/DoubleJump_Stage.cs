﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump_Stage : Player_Base_Stage
{
    

    public DoubleJump_Stage()
    {

    }

    public void Enter()
    {
        
    }

    public void Input()
    {

        if (testplayer.Instance.grounded)
        {

            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
        if (testplayer.Instance.flashcd < 0 && Player_Controller_System.Instance.Button_RB == Player_Controller_System.Button_Stage.down && testplayer.Instance.canflash == true)
        {
            testplayer.Instance.canflash = false;
            testplayer._player.SetStage(testplayer.Instance.flash_stage);
        }
        if (Player_Controller_System.Instance.Button_LB == Player_Controller_System.Button_Stage.down && testplayer.Instance.canrape)
        {
           
            testplayer._player.SetStage(testplayer.Instance.rape_stage);
        }
        if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && testplayer.Instance.canatt)
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

    // Update is called once per frame
    public void Update_()
    {
        Player_Function.FWalk(testplayer.Instance.playergameobj, Player_Controller_System.Instance, testplayer.Instance.speed* testplayer.Instance.jumpmovespeed);
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 30 * Time.deltaTime; //zhongli
        Player_Function.FFace_to();
    }
}
