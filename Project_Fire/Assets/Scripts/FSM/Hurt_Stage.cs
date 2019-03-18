using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Stage : Player_Base_Stage
{
    public Hurt_Stage()
    {

    }

    public void Enter()
    {
        Debug.Log("hurt");
    }

    public void Input()
    {

    }

    // Update is called once per frame
    public void Update_()
    {

        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime;
    }
}
