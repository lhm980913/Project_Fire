using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Stage : Player_Base_Stage
{

    // Start is called before the first frame update
    public Run_Stage()
    {
        
    }

    public void Enter()
    {
      
    }

    public void Input()
    {
        if (Player_Controller_System.Instance.Horizontal_Left == 0)
        {
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
    }

    // Update is called once per frame
    public void Update_()
    {
        Player_Function.FWalk(testplayer.Instance.playergameobj, Player_Controller_System.Instance, testplayer.Instance.speed);
        
    }
}
