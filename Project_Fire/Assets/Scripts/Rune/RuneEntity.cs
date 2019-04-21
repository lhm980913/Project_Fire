﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity : MonoBehaviour
{
    public Rune rune;
    public float Radius = 1.0f;

    private void Awake()
    {
        rune = new XianDan(this);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.PushPanel(UIBaseType.IntroducePanel, this);
            if (Player_Controller_System.Instance.Button_Y == Player_Controller_System.Button_Stage.down)
            {
                if (RuneManager.Instance.PickUpRune(rune))
                {
                    this.gameObject.SetActive(false);
                    UIManager.Instance.PopPanelIntro();
                }
                else
                {
                    UIManager.Instance.ExangeRune(this);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            UIManager.Instance.PopPanelIntro();
        }
    }

    //private void FixedUpdate()
    //{
    //    if (Physics.CheckSphere(transform.position, Radius, 1 << 12))
    //    {
    //        UIManager.Instance.PushPanel(UIBaseType.IntroducePanel, this);
    //        if (Player_Controller_System.Instance.Button_Y == Player_Controller_System.Button_Stage.down)
    //        {
    //            if (RuneManager.Instance.PickUpRune(rune))
    //            {
    //                this.gameObject.SetActive(false);
    //            }
    //            else
    //            {
    //                UIManager.Instance.ExangeRune(this);
    //            }
    //            Debug.Log(Time.realtimeSinceStartup);
    //        }
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, Radius);
    //}
}