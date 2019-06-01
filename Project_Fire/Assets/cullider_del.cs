using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cullider_del : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider[] a = GetComponentsInChildren<BoxCollider>();
        for(int i=0;i<a.Length;i++)
        {
            a[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
