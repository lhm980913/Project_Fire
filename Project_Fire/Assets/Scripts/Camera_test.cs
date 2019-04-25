using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test : UnityEngine.MonoBehaviour
{
    Vector3 a = Vector3.zero;
    public float ttt;
    public float z;

    bool aix;
    // Start is called before the first frame update
    void Start()
    {
        z = -11;
        aix = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector3.SmoothDamp(
        //    this.transform.position,
        //    new Vector3(testplayer.Instance.playergameobj.transform.position.x, testplayer.Instance.playergameobj.transform.position.y, this.transform.position.z), ref a, ttt);
        this.transform.position = new Vector3(testplayer.Instance.transform.position.x, testplayer.Instance.transform.position.y, z);

        if(Input.GetKeyDown(KeyCode.O)||Player_Controller_System.Instance.Xbox_Y==-1)
        {
            if(aix)
            {
                if (z == -11)
                {
                    z = -5;
                }
                else
                {
                    z = -11;
                }
            }
            aix = false;
           // transform.position=transform.position+Vector3.forward;
        }else
        {
            aix = true;
        }
    

    }
}
