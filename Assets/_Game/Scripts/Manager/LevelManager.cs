using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Player player;

    [SerializeField] Level[] levels;
    public Level currentLevel;

    private int levelIndex;

    public void StartGame()
    {
        levelIndex = 0;
        OnLoadLevel(levelIndex);
        OnInit();
        UIManager.Ins.CloseAll();
    }

    public void OnInit()
    {
        player.OnInit();
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

    public void RestartGame()
    {
        // Đóng tất cả UI hiện tại
        UIManager.Ins.CloseAll();

        // Hủy level hiện tại nếu có
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null; // Đặt lại về null để tránh tham chiếu lỗi
        }

        // Reset trạng thái người chơi
        player.OnDespawn(); // Gọi OnDespawn để "dọn dẹp" người chơi
        SimplePool.CollectAll(); // Thu hồi tất cả object trong pool (nếu dùng)
        // Gọi lại StartGame để bắt đầu từ đầu
        StartGame();
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
