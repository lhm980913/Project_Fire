using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangePanel : BasePanel
{
    [HideInInspector]
    public Rune PickedRune;
    public GameObject PickedRuneImage;
    public GameObject[] RuneImages = new GameObject[4];
    public GameObject SelectedOutline;
    private int SelectedIndex = 0;
    private List<int> passiveIndex;
    private List<int> activeIndex;

    private void Awake()
    {
        activeIndex = new List<int>();
        passiveIndex = new List<int>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        activeIndex.Clear();
        passiveIndex.Clear();
        for(int index = 0; index < RuneImages.Length; index++)
        {
            Sprite temp;
            if(RuneManager.Instance.TryGetIcon(RuneManager.Instance.GetRune(index), out temp))
            {
                RuneImages[index].GetComponent<Image>().sprite = temp;
            }
            Rune tempRune;
            if(RuneManager.Instance.TryGetRune(index,out tempRune))
            {
                if(tempRune.runeType == RuneType.active)
                {
                    activeIndex.Add(index);
                }
                else
                {
                    passiveIndex.Add(index);
                }
            }
        }
        Time.timeScale = 0;
    }

    public override void OnExit()
    {
        base.OnExit();
        Time.timeScale = 1;
        UIManager.Instance.PopPanelIntro();
    }

    private void Update()
    {
        SelectRune();
        if (Input.GetKeyDown(KeyCode.R))
        {
            ExchangeRune(SelectedIndex);
        }
    }

    private void SelectRune()
    {
        if(PickedRune.runeType == RuneType.passive)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                    translateSelectedOutline();
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (SelectedIndex < 3)
                {
                    SelectedIndex++;
                    translateSelectedOutline();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                    translateSelectedOutline();
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (SelectedIndex < 1)
                {
                    SelectedIndex++;
                    translateSelectedOutline();
                }
            }
        }
        
    }

    private void ExchangeRune(int index)
    {
        Rune temp = RuneManager.Instance.GetRune(index);
        RuneManager.Instance.DeleteRune(temp,index);
        if(PickedRune == null)
        {
            Debug.Log("PickedRune");
        }
        RuneManager.Instance.AddRune(PickedRune, index);
        PickedRune.SetActiveEvent(index);
        temp.runeEntity.gameObject.SetActive(true);
        temp.runeEntity.gameObject.transform.position = testplayer.Instance.transform.position;
        PickedRune.runeEntity.gameObject.SetActive(false);
        MainPanel.Instance.UpdateImage();
        UIManager.Instance.PopPanel();
    }

    private void translateSelectedOutline()
    {
        SelectedOutline.transform.position = RuneImages[SelectedIndex].transform.position;
    }
}
