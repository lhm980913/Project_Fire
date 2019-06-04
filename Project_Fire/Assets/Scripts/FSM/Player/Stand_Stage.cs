﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand_Stage :  Player_Base_Stage
{
  
    // Start is called before the first frame update
    public Stand_Stage( )
    {
        
        
    }

    public void Enter()
    {
       // Player_Function.FStop(testplayer.Instance.playergameobj);
        //Debug.Log("stand");
        testplayer.Instance.canflash = true;
    }

    public void Input()
    {
        if (Player_Controller_System.Instance.Horizontal_Left != 0)
        {
            testplayer._player.SetStage(testplayer.Instance.run_stage);
        }
        if (Player_Controller_System.Instance.Button_A==Player_Controller_System.Button_Stage.down&&testplayer.Instance.grounded)
        {
             Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.jump_speed);
            //testplayer.Instance.StartCoroutine(testplayer.Instance.Jump(testplayer.Instance.playergameobj, 7));
            testplayer.Instance.canjump = true;
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
        }
        if (!testplayer.Instance.grounded)
        {
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
        }
        if (testplayer.Instance.flashcd < 0 && Player_Controller_System.Instance.Button_RB == Player_Controller_System.Button_Stage.down)
        {
            testplayer._player.SetStage(testplayer.Instance.flash_stage);
        } 
        if (Player_Controller_System.Instance.Button_LB== Player_Controller_System.Button_Stage.down && testplayer.Instance.canrape)
        {
            testplayer._player.SetStage(testplayer.Instance.rape_stage);
        }
        if(Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && testplayer.Instance.canatt)
        {
       
                testplayer._player.SetStage(testplayer.Instance.att_stage);
            
            
        }
        if (Player_Controller_System.Instance.Button_B == Player_Controller_System.Button_Stage.down)
        {
            testplayer._player.SetStage(testplayer.Instance.interaction_stage);
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
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 30 * Time.deltaTime; //zhongli
        Player_Function.FFace_to();
        
    }


}

