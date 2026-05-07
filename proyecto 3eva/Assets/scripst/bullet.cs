using UnityEngine;

public class bullet : MonoBehaviour
{
public GameObject bulletPrefab;
    public int poolSize = 20;

    private GameObject[] bullets;

    void Start()
    {
        bullets = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    // Obtener bala disponible
    public GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }

        return null;
    }
}
