using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Conditional_IsInAttackFieldBox : Conditional
{
    public SharedGameObject enemy;
    private enemy_base enemy_base;
    private float AttackDistance;
    private LayerMask layer;

    public override void OnAwake()
    {
        enemy_base = enemy.Value.GetComponent<enemy_base>();
        AttackDistance = enemy_base.AttackDistance;
        layer = 1 << 12;
    }

    public override TaskStatus OnUpdate()
    {
        if(Physics.BoxCast(transform.position, Vector3.one * 0.5f, transform.forward, Quaternion.identity, AttackDistance, layer))
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
