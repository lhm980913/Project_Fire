using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Att_Stage : Player_Base_Stage
{
    public Att_Stage()
    {

    }
    public void Enter()
    {
        Debug.Log("att");
        Player_Function.FStop(testplayer.Instance.playergameobj);
    }

    public void Input()
    {
      
    }

    // Update is called once per frame
    public void Update_()
    {
        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime; //zhongli

    }
}
