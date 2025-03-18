using UnityEngine;
using TMPro;

public class UIGameOver : UICanvas
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.GameOver);
        
        // Hiển thị điểm hiện tại và điểm cao nhất
        DisplayScores();
    }
    
    private void DisplayScores()
    {
        if (currentScoreText != null && highScoreText != null && UIGamePlay.Instance != null)
        {
            currentScoreText.text = UIGamePlay.Instance.GetCurrentScore().ToString();
            highScoreText.text = UIGamePlay.Instance.GetHighScore().ToString();
        }
    }
    
    public void HomeButton()
    {
        // Quay về màn hình chính
        UIManager.Ins.CloseAll();
        LevelManager.Ins.Home();
    }
    
    public void PlayAgainButton()
    {
        // Bắt đầu game mới
        UIManager.Ins.CloseAll();
        LevelManager.Ins.RestartGame();
        UIManager.Ins.OpenUI<UIGameReady>();
        
        Close(0);
    }
}
