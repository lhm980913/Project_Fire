//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using BehaviorDesigner.Runtime.Tasks;
//using BehaviorDesigner.Runtime;

//public class Action_WalkForward : Action
//{
//    public SharedGameObject enemy;
//    private enemy_base enemy_base;
//    private float MoveSpeed;
//    private Animator animator;

//    public override void OnAwake()
//    {
//        enemy_base = enemy.Value.GetComponent<enemy_base>();
//        MoveSpeed = enemy_base.MoveSpeed;
//        animator = enemy_base.anim;
//    }

//    public override TaskStatus OnUpdate()
//    {
//        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
//        {
//            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime, Space.World);
//            animator.CrossFade("Walk", 0.01f);
//            return TaskStatus.Running;
//        }
//        else
//        {
//            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime, Space.World);
//            return TaskStatus.Running;
//        }
//    }
//}
