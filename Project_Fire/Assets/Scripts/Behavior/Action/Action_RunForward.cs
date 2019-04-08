using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Action_RunForward : Action
{
    public SharedGameObject enemy;
    private enemy_base enemy_base;
    private float RunSpeed;
    private Animator animator;

    public override void OnAwake()
    {
        enemy_base = enemy.Value.GetComponent<enemy_base>();
        RunSpeed = enemy_base.RunSpeed;
        animator = enemy_base.anim;
    }

    public override TaskStatus OnUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            transform.Translate(transform.forward * RunSpeed * Time.deltaTime, Space.World);
            animator.CrossFade("Run", 0.01f);
            return TaskStatus.Running;
        }
        else
        {
            transform.Translate(transform.forward * RunSpeed * Time.deltaTime, Space.World);
            return TaskStatus.Running;
        }
    }
}
