using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_att : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void attingtrue()
    {
        this.GetComponentInParent<enemy_base>().atting = true;
    }
    void attingfalse()
    {
        this.GetComponentInParent<enemy_base>().atting = false;
    }
}
