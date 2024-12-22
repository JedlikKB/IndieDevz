using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;            // Ellens�g �letereje
    public GameObject pickupPrefab;   // Pickup prefab hivatkoz�s
    public int pointsOnDestroy = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a j�t�kos l�ved�ke eltal�lja
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(1);              // Sebz�s okoz�sa
            Destroy(other.gameObject);  // L�ved�k megsemmis�t�se
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
        // 50% es�ly, hogy Pickup jelenjen meg
        float chance = Random.Range(0f, 1f);  // V�letlensz�m 0 �s 1 k�z�tt
        if (chance <= 0.3f)  // 30% es�ly
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
