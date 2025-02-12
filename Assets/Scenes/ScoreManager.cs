using System.IO; // 用于文件操作
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerScore
{
    public int score; // 玩家得分

    public PlayerScore(int score)
    {
        this.score = score;
    }
}

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // 用于显示得分的UI文本
    private int score = 0; // 初始得分
    public GameOverManager gameOverManager; // 引用游戏结束管理器

    private string filePath; // JSON 文件路径

    void Start()
    {
        // 设置 JSON 文件路径
        filePath = Application.persistentDataPath + "/score.json";
        Debug.Log("JSON 文件路径: " + filePath);

        // 初始化得分显示
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points; // 增加分数
        UpdateScoreText(); // 更新UI文本

        // 检查分数是否达到100
        if (score >= 100)
        {
            TriggerGameOver();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // 更新UI显示
        }
        else
        {
            Debug.LogError("ScoreText 未设置，请检查 ScoreManager 脚本中的引用！");
        }
    }

    private void TriggerGameOver()
    {
        if (gameOverManager != null)
        {
            gameOverManager.GameOver(); // 调用游戏结束逻辑

            // 在游戏结束时保存分数到 JSON 文件
            SaveScore();
        }
        else
        {
            Debug.LogError("GameOverManager 未设置，请检查 ScoreManager 脚本中的引用！");
        }
    }

    // 保存分数到 JSON 文件
    private void SaveScore()
    {
        PlayerScore playerScore = new PlayerScore(score); // 创建 PlayerScore 对象

        string json = JsonUtility.ToJson(playerScore); // 将对象转换为 JSON 字符串

        File.WriteAllText(filePath, json); // 写入到文件中

        Debug.Log("保存成功: " + json);
    }
}
