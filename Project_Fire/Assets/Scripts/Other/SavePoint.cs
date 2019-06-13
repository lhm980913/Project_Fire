using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Light Fire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneSystem.instance.UpdateSavePoint(other.transform.position,this);
            Fire.color = new Color(0.25f, 0.55f, 1);
        }
    }
}
