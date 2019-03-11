using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Function 
{


    static public void FWalk(GameObject player, Player_Controller_System inp,float speed)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.right * inp.Horizontal_Left * speed;
    }
    static public void FStop(GameObject player)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
   

}
