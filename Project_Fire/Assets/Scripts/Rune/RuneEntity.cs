using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEntity : UnityEngine.MonoBehaviour
{
    public Rune rune;

    private void Awake()
    {
        rune = new LianDao(this);
    }
    private void OnTriggerStay(Collider other)
    {
        PanelOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PanelOff(other);
    }

    protected void PanelOn(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.PushPanel(UIBaseType.IntroducePanel, this);
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Button_Y"))
            {
                if (RuneManager.Instance.PickUpRune(rune))
                {
                    this.gameObject.SetActive(false);
                    MainPanel.Instance.UpdateImage();
                    UIManager.Instance.PopPanelIntro();
                }
                else
                {
                    UIManager.Instance.ExangeRune(this);
                }
            }
        }
    }
    
    protected void PanelOff(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.PopPanelIntro();
        }
    }
}
