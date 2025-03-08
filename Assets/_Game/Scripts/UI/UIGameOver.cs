using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.GameOver);
    }
    
    public void RestartButton()
    {
        GameManager.Ins.ChangeState(GameState.GamePlay);
        Close(0.5f);
    }
}
