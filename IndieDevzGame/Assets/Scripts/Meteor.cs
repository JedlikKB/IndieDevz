using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a j�t�kos haj�val �tk�zik
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Sebz�s a j�t�kosnak
            }
            Destroy(gameObject); // Meteor megsemmis�t�se
        }
        // Ha a j�t�kos l�ved�k�vel �tk�zik
        else if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject); // L�ved�k megsemmis�t�se
            Destroy(gameObject); // Meteor megsemmis�t�se
        }
    }
}
