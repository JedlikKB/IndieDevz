using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject movingEnemyPrefab; // Új hajó prefab
    public int numberOfEnemies = 3; // Hány hajót spawnoljunk

    public float maxXOffset = 5f; // X tengely maximum
    public float maxYOffset = 5f; // Y tengely maximum

    void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnMovingEnemy();
        }
    }

    void SpawnMovingEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            transform.position.x + Random.Range(0, maxXOffset),
            transform.position.y + Random.Range(0, maxYOffset)
        );

        Instantiate(movingEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
