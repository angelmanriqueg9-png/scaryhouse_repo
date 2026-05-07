using UnityEngine;

public class playercontroller : MonoBehaviour
{
[Header("Movimiento")]
    public float speed = 5f;

    [Header("Vida")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireCooldown = 0.3f;

    private float nextFireTime;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        // Guardar dirección
        if (movement != Vector2.zero)
        {
            lastDirection = movement;
        }

        // Disparo
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = lastDirection * bulletSpeed;
    }

    // Recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador muerto");
        Destroy(gameObject);
    }
}
