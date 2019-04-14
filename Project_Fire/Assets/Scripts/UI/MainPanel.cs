using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : BasePanel
{
    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UIManager.Instance.PushPanel(UIBaseType.MapPanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.Instance.PushPanel(UIBaseType.PausePanel);
            }
        }
    }
}
