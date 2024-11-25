using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Tốc độ di chuyển của bóng (có thể tùy chỉnh từ Inspector)
    public float speed = 5f;

    // Biến kiểm tra xem bóng đã được kích hoạt hay chưa
    private bool isLaunched = false;

    // Rigidbody2D của bóng
    private Rigidbody2D rb;

    // Vị trí ban đầu của bóng
    private Vector3 initialPosition;

    void Start()
    {
        // Lấy Rigidbody2D của bóng
        rb = GetComponent<Rigidbody2D>();

        // Lưu lại vị trí ban đầu của bóng
        initialPosition = transform.position;

        // Đảm bảo bóng không di chuyển trước khi nhấn Space
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        // Kiểm tra nếu nhấn phím Space và bóng chưa được kích hoạt
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            // Gửi bóng bay theo chiều ngang (phải hoặc trái)
            rb.velocity = Vector2.right * speed; // Nếu muốn bay trái, dùng Vector2.left

            // Đánh dấu bóng đã được kích hoạt
            isLaunched = true;
        }

        // Kiểm tra nếu nhấn phím R để reset bóng
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }

    // Hàm reset bóng về trạng thái ban đầu
    void ResetBall()
    {
        // Đưa bóng về vị trí ban đầu
        transform.position = initialPosition;

        // Đặt vận tốc về 0
        rb.velocity = Vector2.zero;

        // Đặt lại trạng thái chưa được kích hoạt
        isLaunched = false;
    }
}

