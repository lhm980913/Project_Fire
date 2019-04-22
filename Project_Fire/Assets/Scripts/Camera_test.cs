using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test : UnityEngine.MonoBehaviour
{
    Vector3 a = Vector3.zero;
    public float ttt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector3.SmoothDamp(
        //    this.transform.position,
        //    new Vector3(testplayer.Instance.playergameobj.transform.position.x, testplayer.Instance.playergameobj.transform.position.y, this.transform.position.z), ref a, ttt);
       
        if(Input.GetKeyDown(KeyCode.O))
        {
            transform.position=transform.position+Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = transform.position - Vector3.forward;
        }

    }
}
