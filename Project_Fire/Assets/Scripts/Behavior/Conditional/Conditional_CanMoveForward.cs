using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Conditional_CanMoveForward : Conditional
{
    public override TaskStatus OnUpdate()
    {
        bool a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);//wall
        bool b = Physics.CheckBox(transform.position + transform.forward * 2 - transform.up, Vector3.one, Quaternion.identity, 1 << 9);//keng
        if (a || !b)
        {
            
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
    }
}
