using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Conditional_IsAttackCDComplete : Conditional
{
    public SharedGameObject enemy;
    private float HitCD;
    private float deltaTime;

    public override void OnAwake()
    {
        HitCD = enemy.Value.GetComponent<enemy_base>().HitCD;
        deltaTime = 0;
    }

    public override TaskStatus OnUpdate()
    {
        if(deltaTime <= 0)
        {
            deltaTime = HitCD;
            return TaskStatus.Success;
        }
        else
        {
            deltaTime -= Time.deltaTime;
            return TaskStatus.Running;
        }
    }

}
