using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : BasePanel
{
    private void Update()
    {
        if (IsTop)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UIManager.Instance.PopPanel();
            }
        }
    }

}