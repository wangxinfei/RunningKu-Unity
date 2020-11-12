using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager  {

    #region 单例模式
    private static EventManager instance;
    public static EventManager Instance()
    {
        if (instance == null)
            instance = new EventManager();
        return instance;
    }
    private EventManager() { }
    #endregion

    private UnityAction BtnAction;
    public void AddBtnAction(UnityAction call)
    {
        BtnAction += call;
    }
    public void DelBtnAction(UnityAction call)
    {
        BtnAction += call;
    }
    public void InvokeBtnAction(UnityAction call)
    {
        if(BtnAction!=null)
            BtnAction();
    }
}
