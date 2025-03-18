using System;
using UnityEngine;

public enum GameState {MainMenu, Ready, GamePlay, GameOver}

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;
    public static bool GamePaused { get; private set; } = true;
    
    // Event that will be triggered when game state changes
    public static event Action<GameState> OnGameStateChanged;

    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
        
        // Set paused state based on game state
        GamePaused = gameState != GameState.GamePlay;
        
        // Notify subscribers
        OnGameStateChanged?.Invoke(gameState);
    }
    
    public bool IsState(GameState gameState) => this.gameState == gameState;

    private void Awake()
    {
        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * maxScreenHeight), maxScreenHeight, true);
        }
    }

    private void Start()
    {
        UIManager.Ins.OpenUI<UIMainMenu>();
        // Start in MainMenu state
        ChangeState(GameState.MainMenu);
    }

    private void Update()
    {
        // Start game on tap when in Ready state
        if (IsState(GameState.Ready) && Input.GetMouseButtonDown(0))
        {
            ChangeState(GameState.GamePlay);
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<UIGamePlay>();
        }
    }

    // Call this method when starting a new game
    public void StartNewGame()
    {
        ChangeState(GameState.Ready);
    }
}
