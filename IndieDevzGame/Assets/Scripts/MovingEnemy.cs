using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    // Mozgás Beállítások
    public float moveRange = 2f; // Mennyit mozogjon fel-le az Y tengely mentén
    public float moveSpeed = 2f; // Mozgás sebessége
    private float startingY; // Kezdő Y pozíció
    public int pointsOnDestroy = 10;


    // Életerő és Tulajdonságok
    public int health = 3;

    void Start()
    {
        // Tároljuk a kezdő Y pozíciót
        startingY = transform.position.y;
    }

    void Update()
    {
        // Fel-le mozgás
        float newY = startingY + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector2(transform.position.x, newY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha lövedéket talál el
        if (other.CompareTag("PlayerProjectile"))
        {
            health--;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Die();
            }
        }
        // Ha játékossal ütközik
        else if (other.CompareTag("Player"))
        {
            // Játékos sebzése
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1); // Sebzés mennyisége
            }
            Die();
        }
    }

    void Die()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        ScoreManager.AddScore(pointsOnDestroy);
        Destroy(gameObject);
    }

}
