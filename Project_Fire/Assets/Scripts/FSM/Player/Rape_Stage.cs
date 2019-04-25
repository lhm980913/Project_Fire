using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rape_Stage : Player_Base_Stage
{
    Transform playerTransform;
    float time;
    Vector3 target;
    float initDistance;
    Vector3 dir;
    Quaternion original;
    public Rape_Stage()
    {

    }

    public void Enter()
    {
        
        CameraEffectSystem.Instance.FMotionVector();
        Debug.Log("rape");
        playerTransform = testplayer.Instance.playergameobj.transform;
        time = 0;
        target = testplayer.Instance.target_pos;

        original = testplayer.Instance.transform.rotation;
        testplayer.Instance.transform.LookAt(target);

        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        initDistance = (target - playerTransform.position).sqrMagnitude;
        testplayer.Instance.anim.SetBool("AfterRope", true);
        testplayer.Instance.anim.SetBool("isThrowing", true);
        dir =Vector3.Normalize( target - testplayer.Instance.transform.position);
        if (target.x - testplayer.Instance.transform.position.x < 0)
        {
            testplayer.Instance.face_to = -1;
        }
        else
        {
            testplayer.Instance.face_to = 1;
        }
    }

    public void Input()
    {
        if(Vector3.Distance(testplayer.Instance.transform.position, target)<0.2f )
        {
            Player_Function.FJump(testplayer.Instance.playergameobj, testplayer.Instance.little_jump_speed);
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
            testplayer.Instance.transform.rotation = original;
            testplayer.Instance.anim.SetFloat("DistancePercent", 1);
            testplayer.Instance.anim.SetTrigger("ArrivePoint");
        }
    }

    // Update is called once per frame
    public void Update_()
    {
        //Player_Function.FRape(testplayer.Instance.gameObject, testplayer.Instance.target_pos, testplayer.Instance.rapespeed, Vector3.zero);
        if (!testplayer.Instance.anim.GetBool("isThrowing"))
        {
            float percent = (target - playerTransform.position).sqrMagnitude / initDistance;
            testplayer.Instance.anim.SetFloat("DistancePercent", 1-percent);

            Player_Function.FRape1(testplayer.Instance.gameObject, target, testplayer.Instance.rapespeed, playerTransform.position, ref time);
        }
        
    }
}
