using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Player player;
    
    [SerializeField] Level[] levels;
    public Level currentLevel;
    
    private int levelIndex;

    public void Start()
    {
        levelIndex = 0;
        OnLoadLevel(levelIndex);
    }
    
    public void OnLoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[level]);
    }
    
    public void PlayerDeath(Player p)
    {
        if (p is Player)
        {
            UIManager.Ins.CloseAll();
            Fail();
        }
    }

    public void Fail()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIGameOver>();
    }

    public void Home()
    {
        UIManager.Ins.CloseAll();
        OnLoadLevel(levelIndex);
        UIManager.Ins.OpenUI<UIMainMenu>();
        
    }
}
