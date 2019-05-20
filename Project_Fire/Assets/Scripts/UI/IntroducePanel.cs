using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroducePanel : BasePanel
{
    //[HideInInspector]
    public Rune IntroducedRune; 
    [SerializeField]
    private Image IconImage;
    [SerializeField]
    private Text RuneName;
    [SerializeField]
    private Text IntroduceText;

    public override void OnEnter()
    {
        base.OnEnter();
        DisplayRune(IntroducedRune);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public void DisplayRune(Rune rune)
    {
        Sprite sprite;
        if(RuneManager.Instance.TryGetIcon(rune, out sprite))
        {
            IconImage.sprite = sprite;
        }
        RuneName.text = rune.RuneName;
    }
}
