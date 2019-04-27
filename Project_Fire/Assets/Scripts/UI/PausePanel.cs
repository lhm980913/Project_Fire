using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : BasePanel
{
    public GameObject SelectedOutline;
    public GameObject[] goArray;
    private int index;

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
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (index > 0) index--;
                translateSelectedOutline();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index < goArray.Length-1) index++;
                translateSelectedOutline();
            }
            if (Input.GetKeyDown(KeyCode.Escape)||Player_Controller_System.Instance.Button_Start==Player_Controller_System.Button_Stage.down)
            {
                UIManager.Instance.PopPanel();
            }
        }
    }

    private void translateSelectedOutline()
    {
        SelectedOutline.transform.position = goArray[index].transform.position;
    }
}