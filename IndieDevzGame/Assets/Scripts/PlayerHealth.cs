using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;        // Maximális életerő
    private int currentHealth;       // Aktuális életerő
    public Slider healthSlider;      // UI Slider az életerőhöz
    public GameObject gameOverPanel;  // Game Over képernyő
    public Text gameOverText;  // Game Over üzenet

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  // Kezdetben rejtve van a Game Over panel
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha az ellenfél lövedéke eltalálja
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);           // Sebzést okoz
            Destroy(other.gameObject); // Lövedék megsemmisítése
        }
        // Ha az ellenfélnek ütközik
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);           // Sebzés az ellenségtől
        }
        // Ha a játékos felveszi a gyógyító pickupot
        else if (other.CompareTag("Pickup"))
        {
            Pickup pickup = other.GetComponent<Pickup>();
            if (pickup != null)
            {
                Heal(pickup.healthAmount);  // Gyógyítás
                Debug.Log("Pickup Felvéve!");
            }
            Destroy(other.gameObject);      // Pickup megsemmisítése
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Nem mehet 0 alá
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Nem mehet max fölé
        healthSlider.value = currentHealth;
    }

    void Die()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over!";
    }

    public void RestartGame()
    {
        // Újraindítja a játékot, új jelenet betöltésével
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        // Vissza a főmenübe
        SceneManager.LoadScene("MainMenu");
    }
}
