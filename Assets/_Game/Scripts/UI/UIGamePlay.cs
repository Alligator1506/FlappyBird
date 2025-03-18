using UnityEngine;
using TMPro;

public class UIGamePlay : UICanvas
{
    public static UIGamePlay Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;
    private int highScore = 0;

    public override void Setup()
    {
        base.Setup();
        Instance = this;
    }

    public override void Open()
    {
        base.Open();
        
        // Lấy điểm cao nhất từ PlayerPrefs
        highScore = PlayerPrefs.GetInt(Constant.HIGH_SCORE_KEY, 0);
    
        ResetScore();
    }
    
    public override void CloseDirectly()
    {
        base.CloseDirectly();
    }
    
    public void PauseButton()
    {
        // Optional: Add pause functionality here
        // UIManager.Ins.OpenUI<UIPause>();
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
        
        // Cập nhật điểm cao nhất nếu cần
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(Constant.HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }
    }
    
    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }
    
    public int GetCurrentScore() => score;
    
    public int GetHighScore() => highScore;

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
} 