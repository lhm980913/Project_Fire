using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    public Image[] RuneImages = new Image[4];
    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Tab)|| Player_Controller_System.Instance.Button_Back == Player_Controller_System.Button_Stage.down)
            {
                UIManager.Instance.PushPanel(UIBaseType.MapPanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Player_Controller_System.Instance.Button_Start == Player_Controller_System.Button_Stage.down)
            {
                UIManager.Instance.PushPanel(UIBaseType.PausePanel);
            }
        }
    }
}
