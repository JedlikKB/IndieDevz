using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss : MonoBehaviour
{
    // Életerő Beállítások
    public int maxHealth = 50;
    private int currentHealth;

    // UI Beállítások
    public Slider healthBar;
    public GameObject victoryText; // Győzelem szöveg

    // Lövési Beállítások
    public GameObject enemyProjectile_0;
    public Transform shootPoint;
    public float minProjectileSpeed = 3f;
    public float maxProjectileSpeed = 8f;
    public float fireRate = 2f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        // Győzelem szöveg elrejtése
        if (victoryText != null)
            victoryText.SetActive(false);

        // Lövési ciklus elindítása
        StartCoroutine(RandomFirePatterns());
    }

    // Véletlenszerű Lövési Minta Választó
    IEnumerator RandomFirePatterns()
    {
        while (currentHealth > 0)
        {
            int pattern = Random.Range(0, 3);
            switch (pattern)
            {
                case 0:
                    StartCoroutine(ShootStraight());
                    break;
                case 1:
                    StartCoroutine(ShootSpread());
                    break;
                case 2:
                    StartCoroutine(ShootWave());
                    break;
            }

            float waitTime = Random.Range(1f, fireRate);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Lövési Minták
    IEnumerator ShootStraight()
    {
        Shoot(Vector2.left);
        yield return null;
    }

    IEnumerator ShootSpread()
    {
        for (int i = -1; i <= 1; i++)
        {
            Vector2 direction = new Vector2(-1, i * 0.5f).normalized;
            Shoot(direction);
        }
        yield return null;
    }

    IEnumerator ShootWave()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 waveDir = new Vector2(-1f, Mathf.Sin(Time.time * 5f)).normalized;
            Shoot(waveDir);
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Lövedék Kilövése
    void Shoot(Vector2 direction)
    {
        if (enemyProjectile_0 != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(enemyProjectile_0, shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0f;

                float randomSpeed = Random.Range(minProjectileSpeed, maxProjectileSpeed);
                rb.linearVelocity = direction * randomSpeed;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                projectile.transform.rotation = Quaternion.Euler(0, 0, angle);

                float randomDisappearTime = Random.Range(2f, 5f);
                Destroy(projectile, randomDisappearTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(5);
            Destroy(other.gameObject);
        }
    }

    // Sebzés Kezelése
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Halál Kezelése
    void Die()
    {
        Debug.Log("A boss legyőzve!");

        // Győzelmi Szöveg Aktiválása
        if (victoryText != null)
            victoryText.SetActive(true);

        // Boss Megsemmisítése
        Destroy(gameObject);
    }
}
