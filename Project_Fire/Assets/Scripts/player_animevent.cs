using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animevent : MonoBehaviour
{
    public AnimationCurve ac;
    public void goback()
    {
        //  testplayer.Instance.GetComponent<Rigidbody>().velocity -= testplayer.Instance.transform.right * 2;
        StartCoroutine(back());       
    }
    public void gofront()
    {
        StartCoroutine(front());


    }
    IEnumerator back()
    {
        float count = 0;
        while(count<0.3f)
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = testplayer.Instance.transform.right* -testplayer.Instance.face_to * 6;
            count += Time.deltaTime;
            yield return null;
        }

       
        yield return null;
    }
    IEnumerator front()
    {
        float count = 0;
        while (count < 0.3f)
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = testplayer.Instance.transform.right * testplayer.Instance.face_to * 5;
            count += Time.deltaTime;
            yield return null;
        }


        yield return null;
    }



}
