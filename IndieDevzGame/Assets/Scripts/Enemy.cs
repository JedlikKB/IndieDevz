using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Ellenség prefab
    public Vector2 spawnAreaMin;    // Megjelenítési terület bal alsó sarka
    public Vector2 spawnAreaMax;    // Megjelenítési terület jobb felsõ sarka
    public float spawnInterval = 3f;  // Megjelenítési idõköz másodpercben
    public int maxEnemies = 5;      // Maximális ellenségszám
    private int currentEnemies = 0; // Jelenleg aktív ellenségek száma

    void Start()
    {
        // Indítsd el az ellenségek megjelenítését
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies) return;

        // Véletlenszerû hely kiválasztása
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(x, y);

        // Ellenség megjelenítése
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
}
