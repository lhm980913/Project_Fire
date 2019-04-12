//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using BehaviorDesigner.Runtime.Tasks;
//using BehaviorDesigner.Runtime;

//public class Conditional_CanSeePlayerBox : Conditional
//{
//    public SharedGameObject enemy;
//    private enemy_base enemy_base;
//    private float VisionDistance;
//    private LayerMask layer;

//    public override void OnAwake()
//    {
//        enemy_base = enemy.Value.GetComponent<enemy_base>();
//        VisionDistance = enemy_base.VisionDistance;
//        layer = 1 << 12;
//    }

//    public override TaskStatus OnUpdate()
//    {
//        //if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, transform.forward, Quaternion.identity, VisionDistance, layer))
//        //{
//        //    return TaskStatus.Success;
//        //}
//        //else
//        //{
//        //    return TaskStatus.Failure;
//        //}
//        if (Physics.CheckBox(transform.position + Vector3.down, Vector3.one + VisionDistance * Vector3.right, Quaternion.identity, layer))
//        {
//            return TaskStatus.Success;
//        }
//        else
//        {
//            return TaskStatus.Failure;
//        }
//    }
//}
