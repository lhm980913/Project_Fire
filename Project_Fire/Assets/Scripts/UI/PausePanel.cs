using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePanel : BasePanel
{
    public GameObject SelectedOutline;
    public GameObject[] goArray;
    public string sceneName;
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
            if (Input.GetButtonDown("Button_A"))
            {
                ExecuteButton();
            }
            if (Input.GetKeyDown(KeyCode.W)||Player_Controller_System.Instance.DPad_Up)
            {
                if (index > 0) index--;
                translateSelectedOutline();
            }
            if (Input.GetKeyDown(KeyCode.S) || Player_Controller_System.Instance.DPad_Down)
            {
                if (index < goArray.Length-1) index++;
                translateSelectedOutline();
            }
            if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("Button_Start"))
            {
                UIManager.Instance.PopPanel();
            }
        }
    }

    private void translateSelectedOutline()
    {
        SelectedOutline.transform.position = goArray[index].transform.position;
    }

    private void ExecuteButton()
    {
        switch (index)
        {
            case 0:
                ResumeGame();
                break;
            case 1:
                LoadScene();
                break;
            default:
                break;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResumeGame()
    {
        UIManager.Instance.PopPanel();
    }
}