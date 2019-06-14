using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform AnotherPortal;
    private void OnTriggerEnter(Collider other)
    {
        if(SceneSystem.instance.GateCoolDownTime <= 0)
        {
            if (other.CompareTag("Player"))
            {
                if (AnotherPortal)
                {
                    SceneSystem.instance.UseGate();
                    Debug.Log(AnotherPortal.position);
                    DelayTranslate(other.transform);
                }
            }
        }
    }

    void DelayTranslate(Transform transform)
    {
        transform.position = AnotherPortal.position;
    }
}
