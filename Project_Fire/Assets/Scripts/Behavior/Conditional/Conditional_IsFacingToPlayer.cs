using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class Conditional_IsFacingToPlayer : Conditional
{
    public SharedGameObject player;

    public override TaskStatus OnUpdate()
    {
        Vector3 dir = player.Value.transform.position - transform.position;
        if(dir.x * transform.transform.forward.x <= 0)
        {
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
    }
}
