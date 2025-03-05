using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }
    
    // public void ShopButton()
    // {
    //     UIManager.Ins.OpenUI<UIShop>();
    //     Close(0);
    // }
    //
    // public void PlayButton()
    // {
    //     LevelManager.Ins.OnPlay();
    //     UIManager.Ins.OpenUI<UIGameplay>();
    //
    //     Close(0.5f);
    // }


}
