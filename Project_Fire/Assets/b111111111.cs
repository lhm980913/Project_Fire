using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b111111111 : UnityEngine.MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="map")
        {
            Destroy(other.gameObject);
        }
    }
}
