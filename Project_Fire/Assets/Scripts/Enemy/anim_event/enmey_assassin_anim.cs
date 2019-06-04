using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmey_assassin_anim : MonoBehaviour
{
    public enemy_assassin assassin;
    private void Awake()
    {
        assassin = GetComponentInParent<enemy_assassin>();
    }
    void chuansong()
    {
        if(Physics.Raycast(testplayer.Instance.transform.position -testplayer.Instance.face_to * Vector3.right * 1f, testplayer.Instance.face_to * Vector3.right * 1f,3,1<<9))
        {
            assassin.transform.position = testplayer.Instance.transform.position + testplayer.Instance.face_to * Vector3.right * 1f;
            assassin.faceto = -testplayer.Instance.face_to;
        }
        else
        {
            assassin.transform.position = testplayer.Instance.transform.position - testplayer.Instance.face_to * Vector3.right * 1f;
            assassin.faceto = testplayer.Instance.face_to;
        }

    }
   
}
