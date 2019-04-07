using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Action_Idle : Action
{
    public SharedGameObject enemy;
    private enemy_base enemy_base;
    private Animator animator;

    public override void OnAwake()
    {
        enemy_base = enemy.Value.GetComponent<enemy_base>();
        animator = enemy_base.anim;
    }

    public override TaskStatus OnUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.CrossFade("Idle", 0.01f);
            return TaskStatus.Running;
        }
        else
        {
            return TaskStatus.Running;
        }
    }
}
