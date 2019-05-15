using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fangda : MonoBehaviour
{
    Transform[] transforms;
    // Start is called before the first frame update
    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();
        for(int i = 0;i<transforms.Length;i++)
        {
            transforms[i].localScale = 2*Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
