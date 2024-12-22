using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;            // Ellenség életereje
    public GameObject pickupPrefab;   // Pickup prefab hivatkozás
    public int pointsOnDestroy = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a játékos lövedéke eltalálja
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(1);              // Sebzés okozása
            Destroy(other.gameObject);  // Lövedék megsemmisítése
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 50% esély, hogy Pickup jelenjen meg
        float chance = Random.Range(0f, 1f);  // Véletlenszám 0 és 1 között
        if (chance <= 0.3f)  // 30% esély
        {
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            Debug.Log("Pickup Megjelent!");
        }
        else
        {
            Debug.Log("Nincs Pickup!");
        }

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        ScoreManager.AddScore(pointsOnDestroy);
        Destroy(gameObject);
    }
}
