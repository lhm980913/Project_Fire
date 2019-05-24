using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Att_Stage : Player_Base_Stage
{
    float ttt = 0.3f;
    float attcount;
    bool atttarget;
    public bool jattack=false;
    public Att_Stage()
    {

    }
    public void Enter()
    {
        

        testplayer.Instance.atting = true;
        testplayer.Instance.canatt = false;
        testplayer.Instance.aa = testplayer.Instance.player_att_speed;
        Player_Function.FStop(testplayer.Instance.playergameobj);
        
        if(!testplayer.Instance.grounded)
        {
            testplayer.Instance.anim.CrossFade("player_jattack1", 0.01f);
            testplayer.Instance.anim.CrossFade("player_jattack", 0.01f);
            //testplayer.Instance.anim.CrossFade("player_attack1", 0.1f);
            jattack = true;
        }
        else
        {
            if(testplayer.Instance.attanim==1)
            {
                testplayer.Instance.anim.CrossFade("player_attack1", 0.01f);
                testplayer.Instance.attanim = 2;
            }
            else if(testplayer.Instance.attanim == 2)
            {
                testplayer.Instance.anim.CrossFade("player_att2", 0.01f);
                testplayer.Instance.attanim = 1;
            }
            
            
            jattack = false;
        }
       

        attcount = testplayer.Instance.tanfan_time;
        ttt = 0.3f;


        //atttarget = Physics.BoxCast(testplayer.Instance.transform.position, Vector3.one, testplayer.Instance.transform.forward,out RaycastHit hit ,Quaternion.identity, 1f, 1<<11);
        //hit.collider.gameObject
    }

    public void Input()
    {
        attcount -= Time.deltaTime;

        if(attcount<0)
        {
            testplayer.Instance.atting = false;
        }

        if(jattack)
        {

        }
        else
        {
           // Player_Function.FStop(testplayer.Instance.playergameobj);
        }
       

        ttt -= Time.deltaTime;
        //if (ttt < 0.1f)
        //{
        //    if (Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down && testplayer.Instance.canatt)
        //    {

        //        jattack = false;

        //        testplayer._player.SetStage(testplayer.Instance.att_stage);
        //        testplayer.Instance.atting = false;


        //    }
         

        //}
        if (ttt<0)
        {
            jattack = false;
            
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
            testplayer.Instance.atting = false;
            
        }
        if (testplayer.Instance.flashcd < 0 && Player_Controller_System.Instance.Button_RB == Player_Controller_System.Button_Stage.down&&testplayer.Instance.canflash)
        {
            jattack = false;
            testplayer.Instance.atting = false;
            testplayer._player.SetStage(testplayer.Instance.flash_stage);
        }

    }

    // Update is called once per frame
    public void Update_()
    {
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 20 * Time.deltaTime; //zhongli

    }
}
