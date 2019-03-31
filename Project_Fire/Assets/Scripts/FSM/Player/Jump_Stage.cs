using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Stage : Player_Base_Stage
{
    public Jump_Stage()
    {

    }

    public void Enter()
    {
        //testplayer.Instance.canflash = true;
        Debug.Log("jump");
    }

    public void Input()
    {
        if (Player_Controller_System.Instance.Button_A == Player_Controller_System.Button_Stage.down)
        {
            Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.jump_speed);
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
        }
        if (testplayer.Instance.grounded)
        {
            
            testplayer._player.SetStage(testplayer.Instance.run_stage);
        }
        if (testplayer.Instance.flashcd < 0 && Player_Controller_System.Instance.Button_RB == Player_Controller_System.Button_Stage.down && testplayer.Instance.canflash ==true)
        {
            testplayer.Instance.canflash = false;
            testplayer._player.SetStage(testplayer.Instance.flash_stage);
        }
        if (Player_Controller_System.Instance.Button_B == Player_Controller_System.Button_Stage.down  && testplayer.Instance.canrape)
        {
            testplayer._player.SetStage(testplayer.Instance.rape_stage);
        }
        if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down&&testplayer.Instance.canatt)
        {
           
                testplayer._player.SetStage(testplayer.Instance.att_stage);
            

        }
    }

    public void Update_()
    {
        Player_Function.FWalk(testplayer.Instance.playergameobj, Player_Controller_System.Instance, testplayer.Instance.speed);
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime; //zhongli
        Player_Function.FFace_to();
    }
}
