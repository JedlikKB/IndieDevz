using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;     // Boss prefab
    public Transform spawnPoint;      // Megjelenési hely

    private bool bossSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !bossSpawned)
        {
            Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            bossSpawned = true; // Csak egyszer jelenjen meg
        }
    }
}
