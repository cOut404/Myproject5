using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // 游戏结束面板

    void Start()
    {
        gameOverPanel.SetActive(false); // 默认隐藏游戏结束面板
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // 显示游戏结束面板
        Time.timeScale = 0; // 暂停游戏
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // 恢复时间流动
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}