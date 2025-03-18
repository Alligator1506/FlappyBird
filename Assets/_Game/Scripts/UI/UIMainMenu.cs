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
        LevelManager.Ins.StartGame();
        UIManager.Ins.OpenUI<UIGameReady>();
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
