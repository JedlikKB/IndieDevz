using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // A l�ved�k prefabja
    public float shootingInterval = 2f; // L�v�s gyakoris�ga
    public float projectileSpeed = 5f;  // L�ved�k sebess�ge

    private void Start()
    {
        // Id?z�tett l�v�s elind�t�sa
        InvokeRepeating(nameof(Shoot), shootingInterval, shootingInterval);
    }

    void Shoot()
    {
        // L�ved�k l�trehoz�sa
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // L�ved�k mozgat�sa balra
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.left * projectileSpeed;
        }
    }
}
