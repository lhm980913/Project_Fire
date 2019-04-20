using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animevent : MonoBehaviour
{
    public AnimationCurve ac;
    public void goback()
    {
        testplayer.Instance.GetComponent<Rigidbody>().velocity -= testplayer.Instance.transform.right * 2;

       
    }
    public void gofront()
    {



    }





}
