using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animevent : UnityEngine.MonoBehaviour
{
    public GameObject weapon;
    
    void open()
    {
        weapon.GetComponent<TrailRenderer>().enabled = true;
    }
    void close()
    {
        weapon.GetComponent<TrailRenderer>().enabled = false;
    }
}
