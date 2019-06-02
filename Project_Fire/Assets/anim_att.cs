using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_att : UnityEngine.MonoBehaviour
{
    public ParticleSystem storePower;

    void attingtrue()
    {
        this.GetComponentInParent<enemy_base>().atting = true;
    }
    void attingfalse()
    {
        this.GetComponentInParent<enemy_base>().atting = false;
    }

    void StorePower()
    {
        storePower.Play();
    }
}
