using System.Collections;
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
        if (Player_Controller_System.Instance.Button_B == Player_Controller_System.Button_Stage.down && testplayer.Instance.canrape)
        {
           
            testplayer._player.SetStage(testplayer.Instance.rape_stage);
        }
        if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && testplayer.Instance.canatt)
        {

            testplayer._player.SetStage(testplayer.Instance.att_stage);


        }

    }

    // Update is called once per frame
    public void Update_()
    {
        Player_Function.FWalk(testplayer.Instance.playergameobj, Player_Controller_System.Instance, testplayer.Instance.speed);
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime; //zhongli
        Player_Function.FFace_to();
    }
}
