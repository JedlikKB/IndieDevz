using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // A lövedék prefabja
    public float shootingInterval = 2f; // Lövés gyakorisága
    public float projectileSpeed = 5f;  // Lövedék sebessége
    public float travelDistance = 10f; // A fix távolság, amit a lövedéknek meg kell tennie

    private void Start()
    {
        // Időzített lövés elindítása
        InvokeRepeating(nameof(Shoot), shootingInterval, shootingInterval);
    }

    void Shoot()
    {
        // Lövedék létrehozása
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Lövedék mozgása balra
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.left * projectileSpeed; // Sebesség beállítása
        }

        // A lövedék mozgatásának és távolságának kezelését is itt végezzük
        StartCoroutine(MoveProjectile(projectile));
    }

    // Lövedék mozgatása és távolságának kezelése
    IEnumerator MoveProjectile(GameObject projectile)
    {
        Vector2 startPosition = projectile.transform.position;

        // Amíg a lövedék nem tette meg a kívánt távolságot, addig mozog
        while (Vector2.Distance(startPosition, projectile.transform.position) < travelDistance)
        {
            yield return null;
        }

        // Lövedék megsemmisítése, ha elérte a kívánt távolságot
        Destroy(projectile);
    }
}
