using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmey_fire_anim : MonoBehaviour
{
    public GameObject fireball;
    public Transform fire_pos;


    public void Fthrow()
    {

        //print("att");
        GameObject a = Instantiate(fireball);
        a.transform.position = fire_pos.position;

    }
    public void Fthrow1()
    {

        //print("att");
        GameObject a = Instantiate(fireball);
        a.transform.position = fire_pos.position;
        GameObject b = Instantiate(fireball);
        b.transform.position = fire_pos.position + Vector3.up;
        GameObject c = Instantiate(fireball);
        c.transform.position = fire_pos.position - Vector3.up;

    }
}
