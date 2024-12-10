using UnityEngine;

public class Enemyy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy lövedék érte-e el
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Ellenség találatot kapott!");
            Destroy(gameObject);  // Ellenség eltávolítása
            Destroy(collision.gameObject);  // Lövedék eltávolítása
        }
    }
}
