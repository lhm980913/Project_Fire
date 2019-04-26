using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager
{
    static private UIManager instance;
    static public UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }

    private Dictionary<UIBaseType, string> panelPathPairs;
    private Dictionary<UIBaseType, BasePanel> Panels;
    private Stack<BasePanel> panelStack;
    private List<DamageUI> DamageUIList;

    [Serializable]
    public class UIPanelInfoList
    {
        public List<UIPanelInfo> PanelList;
    }

    private void ParseUIPanelTypeJson()
    {
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelInfoList temp = JsonUtility.FromJson<UIPanelInfoList>(ta.text);
        //填充字典
        for(int index = 0; index < temp.PanelList.Count; index++)
        {
            panelPathPairs.Add(temp.PanelList[index].PanelType, temp.PanelList[index].path);
        }
    }

    private void InitDamageList()
    {
        for (int i = 0; i < 10; i++)
        {
            AddNewDamageUI();
        }
    }

    private DamageUI GetDamageUI(int damage)
    {
        foreach (var UI in DamageUIList)
        {
            if (!UI.gameObject.activeSelf)
            {
                UI.Enter(damage);
                return UI;
            }
        }
        DamageUI temp = AddNewDamageUI();
        temp.Enter(damage);
        return temp;
    }

    private DamageUI AddNewDamageUI()
    {
        GameObject go = Resources.Load<GameObject>("UIPanel/DamageNumber");
        GameObject temp = UnityEngine.Object.Instantiate(go);
        DamageUIList.Add(temp.GetComponent<DamageUI>());
        temp.SetActive(false);
        return temp.GetComponent<DamageUI>();
    }

    public void DisplayDamageNumber(int damage, Vector3 pos)
    {
        DamageUI temp = GetDamageUI(damage);
        temp.gameObject.transform.position = pos;
    }

    //入栈+显示
    public void PushPanel(UIBaseType type, RuneEntity runeEntity = null)
    {
        if(panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if(panelStack.Count > 0)
        {
            BasePanel top = panelStack.Peek();
            top.OnPause();
        }

        BasePanel panel = GetPanel(type);
        if (!panel)
            Debug.Log("SSS");
        if(type == UIBaseType.ExchangePanel)
        {
            ExchangePanel temp = (ExchangePanel)panel;
            temp.PickedRune = runeEntity.rune;
        }
        if(type == UIBaseType.IntroducePanel)
        {
            IntroducePanel temp = (IntroducePanel)panel;
            temp.IntroducedRune = runeEntity.rune;
        }
        panel.OnEnter();
        panelStack.Push(panel);
    }

    //出栈+隐藏
    public void PopPanel()
    {
        if(panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count <= 0) return;

        BasePanel top = panelStack.Pop();
        top.OnExit();
        if (panelStack.Count <= 0) return;
        top = panelStack.Peek();
        top.OnResume();
    }

    public void PopPanelIntro()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count <= 0) return;
        BasePanel temp = panelStack.Peek();
        if(temp.GetType() == typeof(IntroducePanel))
        {
            PopPanel();
        }

    }

    //更换Rune
    public void ExangeRune(RuneEntity entity)
    {
        PushPanel(UIBaseType.ExchangePanel,entity);
    }

    public BasePanel GetPanel(UIBaseType type)
    {
        if(Panels == null)
        {
            Panels = new Dictionary<UIBaseType, BasePanel>();
        }

        BasePanel panel;
        Panels.TryGetValue(type, out panel);
        if(panel == null)
        {
            string path;
            panelPathPairs.TryGetValue(type, out path);
            GameObject temp = (GameObject)GameObject.Instantiate(Resources.Load(path));
            temp.transform.SetParent(CanvasTransform,false);
            panel = temp.GetComponent<BasePanel>();
            Panels.Add(type, panel);
        }
        return panel;
    }

    public UIManager()
    {
        instance = this;
        panelPathPairs = new Dictionary<UIBaseType, string>();
        DamageUIList = new List<DamageUI>();
        ParseUIPanelTypeJson();
        InitDamageList();
    }

}
