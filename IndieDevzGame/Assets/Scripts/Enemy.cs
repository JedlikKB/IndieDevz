using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1; // Ellenf�l �letereje

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a j�t�kos l�ved�ke eltal�lja
        if (other.CompareTag("PlayerProjectile"))
        {
            health--;
            Destroy(other.gameObject); // L�ved�k megsemmis�t�se

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Ellenf�l megsemmis�t�se
        Destroy(gameObject);
    }
}
