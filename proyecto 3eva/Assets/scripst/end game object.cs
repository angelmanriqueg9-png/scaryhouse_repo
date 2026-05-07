using UnityEngine;

public class endgameobject : MonoBehaviour
{
[Header("Nombre de la escena")]
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el jugador entró
        if (collision.CompareTag("Player"))
        {
            // Cargar siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
