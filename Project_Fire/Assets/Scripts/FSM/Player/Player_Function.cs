using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Function 
{


    static public void FWalk(GameObject player, Player_Controller_System inp,float speed)
    {
       player.GetComponent<Rigidbody>().velocity = Vector3.right * inp.Horizontal_Left * speed + new Vector3(0, player.GetComponent<Rigidbody>().velocity.y,0);
       // player.GetComponent<Rigidbody>().velocity += Vector3.right * inp.Horizontal_Left * speed + new Vector3(0, player.GetComponent<Rigidbody>().velocity.y, 0);
        //  player.gameObject.transform.Translate(Vector3.right * inp.Horizontal_Left *Time.deltaTime * speed,Space.World);

    }
    static public void FStop(GameObject player)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
   static public void FJump(GameObject player , float jump_speed)
    {
       // player.GetComponent<Rigidbody>().velocity += Vector3.up * jump_speed;
        player.GetComponent<Rigidbody>().velocity += Vector3.up * jump_speed;
    }
    static public void FJump(GameObject player, float jump_speed,Vector3 dir)
    {
        //player.GetComponent<Rigidbody>().velocity += dir * jump_speed;
        player.GetComponent<Rigidbody>().velocity += dir * jump_speed;
    }
    static public void FFlash(GameObject player,AnimationCurve ac,float speed,float time,int faceto)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.right * speed * ac.Evaluate(time) *faceto;
       
    }
    static public void FFace_to()
    {
        if (Player_Controller_System.Instance.Horizontal_Left < 0)
        {
            testplayer.Instance.face_to = -1;
        }
        else if (Player_Controller_System.Instance.Horizontal_Left > 0)
        {
            testplayer.Instance.face_to = 1;
        }
    }
    static public void FRape(GameObject player,Vector3 target,float time,Vector3 a)
    {
        player.transform.position = Vector3.SmoothDamp(player.transform.position, target, ref a, time);
    }
    static public void FRape1(GameObject player, Vector3 target, float speed, Vector3 player_begin_pos,ref float a)
    {
       
        a += Time.deltaTime;
        player.transform.position = Vector3.Lerp(player_begin_pos,target,a* speed);
    }

}
