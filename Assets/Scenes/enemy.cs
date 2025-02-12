using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int points = 10; // 击杀该敌人时增加的分数
    private ScoreManager scoreManager; // 引用得分管理器

    void Start()
    {
        // 找到场景中的ScoreManager
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 销毁超出屏幕的敌人
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Bullet"))
            {
                // 增加分数
                if (scoreManager != null)
                {
                    scoreManager.AddScore(points);
                }
            }

            Destroy(collision.gameObject); // 销毁子弹或玩家
            Destroy(gameObject); // 销毁敌人
        }
    }
}

