using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIMainMenu : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }
    
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<UIGamePlay>();
        //LevelManager.Ins.OnPlay();
        //UIManager.Ins.OpenUI<UIGamePlay>();
    
        Close(0);
    }
    
    public void ShopButton()
    {
        UIManager.Ins.OpenUI<UIShop>();
        Close(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
