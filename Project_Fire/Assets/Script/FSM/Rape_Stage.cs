using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rape_Stage : Player_Base_Stage
{
    Vector3 pos;
    float a;
    Vector3 target;
    public Rape_Stage()
    {

    }

    public void Enter()
    {
        pos = testplayer.Instance.playergameobj.transform.position;
        a = 0;
        target = testplayer.Instance.target_pos;
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void Input()
    {
        if(Vector3.Distance(testplayer.Instance.transform.position, target)<0.3f )
        {
            Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.little_jump_speed);
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
    }

    // Update is called once per frame
    public void Update_()
    {
        //Player_Function.FRape(testplayer.Instance.gameObject, testplayer.Instance.target_pos, testplayer.Instance.rapespeed, Vector3.zero);

        Player_Function.FRape1(testplayer.Instance.gameObject, target, testplayer.Instance.rapespeed, pos,ref a);
    }
}
