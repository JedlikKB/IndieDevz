using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1; // Ellenfél életereje

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a játékos lövedéke eltalálja
        if (other.CompareTag("PlayerProjectile"))
        {
            health--;
            Destroy(other.gameObject); // Lövedék megsemmisítése

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Ellenfél megsemmisítése
        Destroy(gameObject);
    }
}
