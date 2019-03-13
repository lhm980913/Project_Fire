using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    CameraEffectSystem instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = CameraEffectSystem.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(instance.FCameraShake());
            Debug.Log("K");
        }
            
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(instance.FTimeScaleControl());
            Debug.Log("J");
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            instance.FRaidalBlurShock();
            Debug.Log("L");
        }
    }

}
