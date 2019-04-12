using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Att_Stage : Player_Base_Stage
{
    float ttt = 0.3f;
    bool atttarget;
    public Att_Stage()
    {

    }
    public void Enter()
    {
        Debug.Log("att");
        testplayer.Instance.atting = true;
        testplayer.Instance.canatt = false;
        testplayer.Instance.aa = testplayer.Instance.player_att_speed;
        Player_Function.FStop(testplayer.Instance.playergameobj);
        if (Player_Controller_System.Instance.Vertical_Left < 0.7 && Player_Controller_System.Instance.Vertical_Left > -0.7)
        {
            testplayer.Instance.anim.SetTrigger("att1");
        }else if(Player_Controller_System.Instance.Vertical_Left > 0.7)
        {
            testplayer.Instance.anim.SetTrigger("att_up");
        }
        else if(Player_Controller_System.Instance.Vertical_Left <-0.7 &&!testplayer.Instance.grounded)
        {
            testplayer.Instance.anim.SetTrigger("att_down");
        }
        else
        {
            testplayer.Instance.anim.SetTrigger("att1");
        }

        
        
        ttt = 0.3f;


        //atttarget = Physics.BoxCast(testplayer.Instance.transform.position, Vector3.one, testplayer.Instance.transform.forward,out RaycastHit hit ,Quaternion.identity, 1f, 1<<11);
        //hit.collider.gameObject
    }

    public void Input()
    {
        Player_Function.FStop(testplayer.Instance.playergameobj);
        ttt -= Time.deltaTime;
      if(ttt<0)
        {
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
            testplayer.Instance.atting = false;
        }
      
    }

    // Update is called once per frame
    public void Update_()
    {
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime; //zhongli

    }
}
