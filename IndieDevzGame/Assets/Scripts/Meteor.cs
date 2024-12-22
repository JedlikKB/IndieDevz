using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a játékos hajóval ütközik
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Sebzés a játékosnak
            }
            Destroy(gameObject); // Meteor megsemmisítése
        }
        // Ha a játékos lövedékével ütközik
        else if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject); // Lövedék megsemmisítése
            Destroy(gameObject); // Meteor megsemmisítése
        }
    }
}
