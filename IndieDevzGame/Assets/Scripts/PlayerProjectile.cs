using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 10f;       // Lovedek sebessege
    public float lifetime = 5f;     // Elettartam masodpercben

    void Start()
    {
        Destroy(gameObject, lifetime); // Megsemmisites adott ido utan
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);         // Mozgas jobbra (x tengely menten)
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);                                    // Lovedek torlese, ha elhagyja a kepernyot

    }
}