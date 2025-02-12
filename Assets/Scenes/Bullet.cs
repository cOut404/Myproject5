using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // 子弹速度

    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime); // 子弹向上移动

        // 如果子弹超出屏幕，则销毁它
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}