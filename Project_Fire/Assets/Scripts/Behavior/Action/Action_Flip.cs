using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Action_Flip : Action
{
    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    }
    public override void OnAwake()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        Flip();
        return TaskStatus.Success;
    }
}
