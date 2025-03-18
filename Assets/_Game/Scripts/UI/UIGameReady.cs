using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameReady : UICanvas
{
    public override void Setup()
    {
        base.Setup();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.Ready);
    }
    
    public override void CloseDirectly()
    {
        base.CloseDirectly();
    }
    
    public void SettingButton()
    {
        //UIManager.Ins.OpenUI<UISetting>();
    }
}
