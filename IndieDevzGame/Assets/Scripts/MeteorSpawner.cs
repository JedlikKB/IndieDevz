using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // A meteor prefab
    public int meteorCount = 10; // Hány meteor jelenjen meg
    public float spawnRangeX = 8f; // Maximum távolság jobbra az X tengelyen
    public float spawnRangeY = 5f; // Maximum távolság felfelé az Y tengelyen

    private void Start()
    {
        SpawnAllMeteors();
    }

    private void SpawnAllMeteors()
    {
        for (int i = 0; i < meteorCount; i++)
        {
            float randomX = Random.Range(0, spawnRangeX); // Pozitív X irányú véletlenszerű hely
            float randomY = Random.Range(0, spawnRangeY); // Pozitív Y irányú véletlenszerű hely
            Vector2 spawnPosition = new Vector2(transform.position.x + randomX, transform.position.y + randomY); // Pozíció kiszámítása
            Instantiate(meteorPrefab, spawnPosition, Quaternion.identity); // Meteor létrehozása
        }
    }
}
