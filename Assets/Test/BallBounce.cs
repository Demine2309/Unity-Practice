using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Rigidbody2D của bóng
    private Rigidbody2D rb;

    // Hệ số ma sát giả lập để điều chỉnh phản xạ
    public float bounceFactor = 1f; // Giá trị >= 1 sẽ tăng độ nảy, < 1 sẽ giảm độ nảy

    void Start()
    {
        // Lấy Rigidbody2D của bóng
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu bóng va chạm với tường bên phải
        if (collision.gameObject.CompareTag("WallRight"))
        {
            // Lấy vận tốc hiện tại của bóng
            Vector2 currentVelocity = rb.velocity;

            // Phản xạ vận tốc theo trục X (đảo dấu trục X)
            Vector2 reflectedVelocity = new Vector2(-currentVelocity.x * bounceFactor, currentVelocity.y);

            // Áp dụng vận tốc mới
            rb.velocity = reflectedVelocity;
        }
    }
}