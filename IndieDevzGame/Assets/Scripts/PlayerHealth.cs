using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maximális életerő
    private int currentHealth;

    public Slider healthSlider; // UI Slider az életerőhöz

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha az ellenfél lövedéke eltalálja
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject); // Lövedék megsemmisítése
        }
        // Ha az ellenfélnek ütközik
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Játékos meghalt!");
        // Itt lehet a játék végét kezelni, pl. újratöltés
    }
}
