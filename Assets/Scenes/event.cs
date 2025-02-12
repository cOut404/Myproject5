using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人预制体
    public float spawnInterval = 2f; // 敌人生成间隔
    public float enemySpeed = 3f; // 敌人移动速度

    void Start()
    {
        // 每隔一段时间生成一个敌人
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 随机生成敌人的 X 坐标
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);

        // 实例化敌人并设置其速度
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.AddComponent<EnemyBehavior>(); // 给敌人添加行为脚本
        newEnemy.GetComponent<EnemyBehavior>().speed = enemySpeed; // 设置敌人的速度
    }
}

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 3f; // 敌人移动速度

    void Update()
    {
        // 敌人向下移动
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 如果超出屏幕范围，则销毁敌人
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("玩家被击中！游戏结束！");
            Destroy(collision.gameObject); // 销毁玩家对象（可选）
            Destroy(gameObject); // 销毁敌人对象
        }
    }
}
