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
            Sprite temp;
            if(RuneManager.Instance.TryGetIcon(RuneManager.Instance.GetRune(index), out temp))
            {
                RuneImages[index].GetComponent<Image>().sprite = temp;
            }
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
        if(PickedRune == null)
        {
            Debug.Log("PickedRune");
        }
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
