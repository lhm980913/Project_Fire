using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSystem : MonoBehaviour
{
    static public ProcessSystem Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void FHitSomething(enemy_base enemy)
    {

    }

    public void FHitBySomething(enemy_base enemy)
    {

    }

    public void FHitEnemyAttack(enemy_base enemy)
    {

    }
}
