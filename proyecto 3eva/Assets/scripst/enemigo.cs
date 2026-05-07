using UnityEngine;

public class enemigo : MonoBehaviour
{
[Header("Movimiento")]
    public float speed = 2f;

    [Header("Vida")]
    public int health = 3;

    [Header("Daño")]
    public int damage = 1;

    private Transform player;

    void Start()
    {
        // Buscar al jugador
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            player = target.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Moverse hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    // Recibir daño
    public void TakeDamage(int amount)
    {
        health -= amount;

        Debug.Log("Vida enemigo: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Hacer daño al jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerHealth =
                collision.gameObject.GetComponent<PlayerController>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
