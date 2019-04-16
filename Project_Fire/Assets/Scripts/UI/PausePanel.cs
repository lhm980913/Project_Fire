using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : BasePanel
{
    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Escape)||Player_Controller_System.Instance.Button_Start==Player_Controller_System.Button_Stage.down)
            {
                UIManager.Instance.PopPanel();
            }
        }
    }
}