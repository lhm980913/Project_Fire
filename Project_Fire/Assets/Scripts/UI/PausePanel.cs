using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : BasePanel
{
    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.Instance.PopPanel();
            }
        }
    }
}