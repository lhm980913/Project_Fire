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

    public override void OnEnter()
    {
        base.OnEnter();
        for(int index = 0; index < RuneImages.Length; index++)
        {
            PickedRuneImage.GetComponent<Image>().sprite = RuneManager.Instance.GetIcon(RuneManager.Instance.GetRune(index));
            RuneImages[index].GetComponent<Image>().sprite = RuneManager.Instance.GetIcon(RuneManager.Instance.GetRune(index));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(SelectedIndex>0)
                SelectedIndex--;
            translateSelectedOutline();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SelectedIndex < 3)
            {
                SelectedIndex++;
                translateSelectedOutline();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ExchangeRune(SelectedIndex);
        }
    }

    private void ExchangeRune(int index)
    {
        Rune temp = RuneManager.Instance.GetRune(index);
        RuneManager.Instance.DeleteRune(temp);
        RuneManager.Instance.AddRune(PickedRune);

        temp.runeEntity.gameObject.SetActive(true);
        temp.runeEntity.gameObject.transform.position = testplayer.Instance.transform.position;
        PickedRune.runeEntity.gameObject.SetActive(false);
        
        UIManager.Instance.PopPanel();
    }

    private void translateSelectedOutline()
    {
        SelectedOutline.transform.position = RuneImages[SelectedIndex].transform.position;
    }
}
