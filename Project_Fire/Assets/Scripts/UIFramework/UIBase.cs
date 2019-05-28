using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BasePanel : UnityEngine.MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    //[HideInInspector]
    public bool IsTop;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OnEnter()
    {
        if(canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.alpha = 1;
        IsTop = true;
    }

    public virtual void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
        IsTop = false;
    }

    public virtual void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
        IsTop = true;
    }

    public virtual void OnExit()
    {
        canvasGroup.alpha = 0;
        IsTop = false;
        canvasGroup.gameObject.SetActive(false);
    }
}
