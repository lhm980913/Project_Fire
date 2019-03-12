using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Stage : Player_Base_Stage
{
    public Flash_Stage()
    {

    }
    public void Enter()
    {
        Debug.Log("flash");
        testplayer.Instance.flashtime = 0;
        testplayer.Instance.flashcd = 0.6f;
    }

    public void Input()
    {
        if(testplayer.Instance.flashtime>testplayer.Instance.ac.keys[2].time)
        {
            if (!testplayer.Instance.grounded)
            {
                testplayer._player.SetStage(testplayer.Instance.jump_stage);
            }
            else
            {
                testplayer._player.SetStage(testplayer.Instance.stand_stage);
            }
        }
    }

    // Update is called once per frame
    public void Update_()
    {
        testplayer.Instance.flashtime += Time.deltaTime;
        Player_Function.FFlash(testplayer.Instance.playergameobj, testplayer.Instance.ac, testplayer.Instance.maxflashspeed, testplayer.Instance.flashtime,testplayer.Instance.face_to);
    }
}
