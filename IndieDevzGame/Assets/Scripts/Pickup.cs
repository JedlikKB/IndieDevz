using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int healthAmount = 1;  // Gy�gy�t�s m�rt�ke

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ha a j�t�kos hozz��r
        {
            Debug.Log("Pickup Felv�ve!");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount);  // Gy�gy�t�s
            }
            Destroy(gameObject);  // Pickup megsemmis�t�se
        }
    }
}
