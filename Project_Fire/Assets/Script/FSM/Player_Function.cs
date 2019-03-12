using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Function 
{


    static public void FWalk(GameObject player, Player_Controller_System inp,float speed)
    {
       player.GetComponent<Rigidbody>().velocity = Vector3.right * inp.Horizontal_Left * speed + new Vector3(0, player.GetComponent<Rigidbody>().velocity.y,0);
      //  player.gameObject.transform.Translate(Vector3.right * inp.Horizontal_Left *Time.deltaTime * speed,Space.World);
    }
    static public void FStop(GameObject player)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
   static public void FJump(GameObject player , float jump_speed)
    {
        player.GetComponent<Rigidbody>().velocity += Vector3.up * jump_speed;
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
}
