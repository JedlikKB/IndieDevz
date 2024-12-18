using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int healthAmount = 1;  // Gyógyítás mértéke

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ha a játékos hozzáér
        {
            Debug.Log("Pickup Felvéve!");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount);  // Gyógyítás
            }
            Destroy(gameObject);  // Pickup megsemmisítése
        }
    }
}
