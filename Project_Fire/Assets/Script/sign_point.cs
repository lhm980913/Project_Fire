using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign_point : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(testplayer.Instance.canrape)
        {
            this.transform.position = testplayer.Instance.target_pos;
        }
        else
        {
            this.transform.position =Vector3.zero;
        }
     
    }
}
