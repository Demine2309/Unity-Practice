using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    //[SerializeField] public GameObject enemyPrefab;
    public float spawnRangeX = 4f; public float spawnRangeY = 4f;
    [SerializeField] public float fireRate = 1f;
    [SerializeField] public float speed = 2f;
    private float nextFire = 0f;
    private Transform player;
    private bool movingRight = true;

    public static int enemiesDestroyed = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Move();

        if (player != null && Mathf.Abs(transform.position.x - player.position.x) < 0.5f)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
    }

    void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= 5.5f)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= -5.5f)
            {
                movingRight = true;
            }
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            enemiesDestroyed++; // Increment the count when an enemy is destroyed
            //SpawnNewEnemy();

            Player playerScript = FindObjectOfType<Player>();
            if (playerScript != null)
            {
                playerScript.UpdateEnemyCountText();
            }
        }
    }

    //void SpawnNewEnemy()
    //{
    //    Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(2.7f, spawnRangeY), transform.position.z);
    //    GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //    newEnemy.SetActive(true);
    //}
}
