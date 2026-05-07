using UnityEngine;

public class te : MonoBehaviour
{
       [Header("Curación")]
    public int healAmount = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si es el jugador
        if (collision.CompareTag("Player"))
        {
            // Obtener script del jugador
            PlayerController player =
                collision.GetComponent<PlayerController>();

            if (player != null)
            {
                // Curar al jugador
                player.Heal(healAmount);

                Debug.Log("Curaste +" + healAmount);

                // Destruir objeto
                Destroy(gameObject);
            }
        }
    }
}
