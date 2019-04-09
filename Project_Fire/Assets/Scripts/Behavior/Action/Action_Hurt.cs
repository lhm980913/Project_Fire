﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Action_Hurt : Action
{
    public SharedGameObject enemy;
    private Animator animator;

    public override void OnAwake()
    {
        animator = enemy.Value.GetComponent<enemy_base>().anim;
    }

    public override TaskStatus OnUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            animator.CrossFade("Hurt", 0.01f);
            return TaskStatus.Running;
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                return TaskStatus.Running;
            }
            else
            {
                animator.Play("Hurt", 0, 0);
                return TaskStatus.Success;
            }
        }
    }
}