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

    //入栈+显示
    public void PushPanel(UIBaseType type)
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
        ParseUIPanelTypeJson();
    }

}
