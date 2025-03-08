using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlay : UICanvas
{
    public override void Setup()
    {
        base.Setup();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.GamePlay);
    }
    
    public override void CloseDirectly()
    {
        base.CloseDirectly();
    }
}
