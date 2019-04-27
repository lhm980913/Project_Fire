using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    static private MainPanel instance;
    static public MainPanel Instance
    {
        get
        {
            return instance;
        }
    }
    public Image[] RuneImages = new Image[4];

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

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

    public void UpdateImage()
    {
        Sprite temp;
        Rune tempRune;
        for (int i = 0; i < 4; i++)
        {
            if(RuneManager.Instance.TryGetRune(i,out tempRune))
            {
                if (RuneManager.Instance.TryGetIcon(tempRune, out temp))
                {
                    RuneImages[i].sprite = temp;
                    RuneImages[i].color = new Color(1, 1, 1, 1);
                }
                else
                {
                    RuneImages[i].color = new Color(1, 1, 1, 0);
                }
            }
            
        }
    }
}
