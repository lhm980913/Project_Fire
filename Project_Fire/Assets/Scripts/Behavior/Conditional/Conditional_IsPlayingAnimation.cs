using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Conditional_IsPlayingAnimation : Conditional
{
    public SharedGameObject enemy;
    public string AnimationName;
    private Animator animator;

    public override void OnAwake()
    {
        animator = enemy.Value.GetComponent<enemy_base>().anim;
    }

    public override TaskStatus OnUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationName))
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
