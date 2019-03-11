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

    public void HitSomething(Enemy enemy)
    {

    }

    public void HitBySomething(Enemy enemy)
    {

    }
}
