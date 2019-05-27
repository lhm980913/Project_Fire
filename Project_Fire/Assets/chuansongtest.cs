using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuansongtest : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            testplayer.Instance.transform.position = pos1.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            testplayer.Instance.transform.position = pos2.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            testplayer.Instance.transform.position = pos3.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            testplayer.Instance.transform.position = pos4.position;

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            testplayer.Instance.transform.position = pos5.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            testplayer.Instance.transform.position = pos6.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            testplayer.Instance.transform.position = pos7.position;
        }
    }
}
