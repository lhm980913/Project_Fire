using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : BasePanel
{
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