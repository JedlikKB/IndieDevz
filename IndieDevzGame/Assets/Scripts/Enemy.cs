using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Ellens�g prefab
    public Vector2 spawnAreaMin;    // Megjelen�t�si ter�let bal als� sarka
    public Vector2 spawnAreaMax;    // Megjelen�t�si ter�let jobb fels� sarka
    public float spawnInterval = 3f;  // Megjelen�t�si id�k�z m�sodpercben
    public int maxEnemies = 5;      // Maxim�lis ellens�gsz�m
    private int currentEnemies = 0; // Jelenleg akt�v ellens�gek sz�ma

    void Start()
    {
        // Ind�tsd el az ellens�gek megjelen�t�s�t
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies) return;

        // V�letlenszer� hely kiv�laszt�sa
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(x, y);

        // Ellens�g megjelen�t�se
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
}
