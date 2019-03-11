using System.Collections;
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
        Player_Function.FStop(testplayer.Instance.playergameobj);
        
    }

    public void Input()
    {
        if (Player_Controller_System.Instance.Horizontal_Left != 0)
        {


            testplayer._player.SetStage(testplayer.Instance.run_stage);
        }
      
    }

    public void Update_()
    {
       
    }
}
