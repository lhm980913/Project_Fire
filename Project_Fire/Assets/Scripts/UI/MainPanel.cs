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
    [SerializeField]
    private Slider Hp;
    [SerializeField]
    private Slider Mp;
    [SerializeField]
    private Text Coin;

    private testplayer player;

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
            if (Input.GetKeyDown(KeyCode.Tab)|| Input.GetButtonDown("Button_Back"))
            {
                UIManager.Instance.PushPanel(UIBaseType.MapPanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Button_Start"))
            {
                UIManager.Instance.PushPanel(UIBaseType.PausePanel);
            }
            if(Input.GetKeyDown(KeyCode.O))
            {
                CameraEffectSystem.Instance.ZoomFov();
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

    public void UpdateHp()
    {
        Hp.value = testplayer.Instance.hp / testplayer.Instance.Hpmax;
    }

    public void UpdateMp()
    {

        Mp.value = testplayer.Instance.mana / testplayer.Instance.Manamax;
    }
}
