using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : BasePanel
{
    public override void OnEnter()
    {
        base.OnEnter();
        Time.timeScale = 0.0f;
    }

    public override void OnExit()
    {
        base.OnExit();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Tab)|| Player_Controller_System.Instance.Button_Back == Player_Controller_System.Button_Stage.down)
            {
                UIManager.Instance.PopPanel();
            }
        }
    }

}