using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // Tốc độ di chuyển
    [SerializeField] public GameObject bulletPrefab; // Prefab của đạn
    [SerializeField] public Transform firePoint; // Điểm bắn đạn
    [SerializeField] public float bulletSpeed = 10f; // Tốc độ đạn

    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] private TextMeshProUGUI enemyCountText;

    private bool isDestroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateEnemyCountText(); // Initialize the enemy count text
    }

    void Update()
    {
        if (!isDestroyed) // Only allow movement and shooting if the player is not destroyed
        {
            // Input handling
            float moveX = Input.GetAxisRaw("Horizontal"); // Left, right
            float moveY = Input.GetAxisRaw("Vertical");   // Up, down
            moveInput = new Vector2(moveX, moveY).normalized;

            // Shooting
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDestroyed) // Only move if the player is not destroyed
        {
            rb.velocity = moveInput * moveSpeed;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Tạo đạn từ Prefab
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Gắn vận tốc cho đạn
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.velocity = firePoint.up * bulletSpeed;
            }

            // Hủy đạn sau 2 giây để tránh quá tải
            Destroy(bullet, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra va chạm với đạn của Enemy
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject); // Hủy tàu người chơi
            Destroy(collision.gameObject); // Hủy đạn
        }
    }

    private void ResetGame()
    {
        // Reset the game by reloading the current scene
        SceneManager.LoadScene(0);
    }

    public void UpdateEnemyCountText()
    {
        // Update the enemy count text
        enemyCountText.text = "" + Enemy.enemiesDestroyed;
    }
}