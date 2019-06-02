using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerweapon : UnityEngine.MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ProcessSystem.Instance.FPlayerWeapon_EnemyWeapon(this);
    }
}
