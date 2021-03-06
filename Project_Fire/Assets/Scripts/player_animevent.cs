﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animevent : UnityEngine.MonoBehaviour
{
    public AnimationCurve ac;
    public ParticleSystem slide_dust;
    public ParticleSystem jump_dust;
    public ParticleSystem tanfaneffect;
    public ParticleSystem jattack;
    public ParticleSystem slide_dust_Main;
    public GameObject player_weapon_att;
    public GameObject player_weapon_jatt;


    ParticleSystem slide;
    ParticleSystem slide_Main;
    ParticleSystem jump;
    ParticleSystem tanfaneffect1;
    ParticleSystem jattack1;
    private void Start()
    {
        slide = Instantiate(slide_dust);
        slide_Main = Instantiate(slide_dust_Main, testplayer.Instance.transform);
        slide.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        jump = Instantiate(jump_dust);
        jump.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        tanfaneffect1 = Instantiate(tanfaneffect);
        jattack1 = Instantiate(jattack,testplayer.Instance.transform);
    }
    public void slidedust()
    {
        slide.transform.position = testplayer.Instance.transform.position + Vector3.down * 0.5f;
        slide.Play();
        slide_Main.Play();
    }

    public void jumpdust()
    {
        jump.transform.position = testplayer.Instance.transform.position + Vector3.down * 0.5f;
        jump.Play();
    }

    public void tanfan()
    {
        tanfaneffect1.transform.position = testplayer.Instance.transform.position + new Vector3(1.8f * testplayer.Instance.face_to, -0.78f, 0 );
        tanfaneffect1.transform.rotation = testplayer.Instance.moudle_player.transform.rotation;
        tanfaneffect1.Play();
    }
    public void Fjattack()
    {
        jattack1.transform.position = testplayer.Instance.transform.position - 0.5f*Vector3.up;
        
        jattack1.startRotation3D = new Vector3(0, (Mathf.PI/2) * testplayer.Instance.face_to, 0);
        jattack1.Play();
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
            testplayer.Instance.GetComponent<Rigidbody>().velocity = testplayer.Instance.transform.right* -testplayer.Instance.face_to * 4;
            count += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator front()
    {
       if( Physics.Raycast(testplayer.Instance.transform.position, Vector3.right * testplayer.Instance.face_to, out RaycastHit info, 8, 1 << 11))
       {
            float dis =Mathf.Abs( info.transform.position.x - testplayer.Instance.transform.position.x)-2f;
            float speed = dis / 0.3f;
       

        float count = 0;
        while (count < 0.3f)
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = testplayer.Instance.transform.right * testplayer.Instance.face_to * speed;
            count += Time.deltaTime;
            yield return null;
        }
        }

        yield return null;
    }


    public void Att()
    {
        Destroy( Instantiate(player_weapon_att, testplayer.Instance.transform.position, Quaternion.Euler(0, 90 * testplayer.Instance.face_to, 0)),0.05f);
    }
    public void JAtt()
    {
        Destroy(Instantiate(player_weapon_jatt, testplayer.Instance.transform.position, Quaternion.Euler(0, 0, 0)), 0.05f);
    }
}
