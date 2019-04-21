using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animevent : MonoBehaviour
{
    public AnimationCurve ac;
    public ParticleSystem slide_dust;
    public ParticleSystem jump_dust;
    public ParticleSystem tanfaneffect;

    ParticleSystem slide;
    ParticleSystem jump;
    ParticleSystem tanfaneffect1;
    private void Start()
    {
        slide = Instantiate(slide_dust);
        slide.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        jump = Instantiate(jump_dust);
        jump.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        tanfaneffect1 = Instantiate(tanfaneffect);
    }
    public void slidedust()
    {
        slide.transform.position = testplayer.Instance.transform.position + Vector3.down * 0.5f;
        slide.Play();
    }

    public void jumpdust()
    {
        jump.transform.position = testplayer.Instance.transform.position + Vector3.down * 0.5f;
        jump.Play();
    }

    public void tanfan()
    {
        tanfaneffect1.transform.position = testplayer.Instance.transform.position + new Vector3(1.81f * testplayer.Instance.face_to, -0.78f, 0 );
        tanfaneffect1.transform.rotation = testplayer.Instance.moudle_player.transform.rotation;
        tanfaneffect1.Play();
    }

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
        while(count<0.5f)
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
        while (count < 0.5f)
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = testplayer.Instance.transform.right * testplayer.Instance.face_to * 5;
            count += Time.deltaTime;
            yield return null;
        }


        yield return null;
    }



}
