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

    public void FHitSomething(Enemy enemy)
    {

    }

    public void FHitBySomething(Enemy enemy)
    {

    }

    public void FHitEnemyAttack(Enemy enemy)
    {

    }
}
