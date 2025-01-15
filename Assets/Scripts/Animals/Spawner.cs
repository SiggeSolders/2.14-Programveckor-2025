using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject deer;
    [SerializeField] GameObject sheep;
    [SerializeField] LayerMask groundLayer; // LayerMask to detect the ground
    int deerNumberSpawned;
    int sheepNumberSpawned;
    GoalsScript goalsScript;
    int lastSpawnedDay = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalsScript = FindAnyObjectByType<GoalsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the day has changed
        if (goalsScript.day != lastSpawnedDay)
        {
            lastSpawnedDay = goalsScript.day;
            SpawnAnimalsForDay(goalsScript.day);
        }
    }

    void SpawnAnimalsForDay(int day)
    {
        switch (day)
        {
            case 1:
                deerNumberSpawned = 10;
                sheepNumberSpawned = 1;
                break;
            case 2:
                deerNumberSpawned = 20;
                sheepNumberSpawned = 6;
                break;
            case 3:
                deerNumberSpawned = 10;
                sheepNumberSpawned = 30;
                break;
            default:
                deerNumberSpawned = 0;
                sheepNumberSpawned = 0;
                break;
        }

        SpawnAnimals(deer, deerNumberSpawned);
        SpawnAnimals(sheep, sheepNumberSpawned);
    }

    void SpawnAnimals(GameObject animalPrefab, int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            // Generate random X and Z within bounds
            float spawnPointX = Random.Range(2, 296);
            float spawnPointZ = Random.Range(2, 296);
            Vector3 spawnPoint = new Vector3(spawnPointX, 100f, spawnPointZ); // Start high above the terrain

            // Find the Y position using raycast
            if (Physics.Raycast(spawnPoint, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                spawnPoint = hit.point; // Adjust spawn point to ground level
                Instantiate(animalPrefab, spawnPoint, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"Failed to find ground at X:{spawnPointX}, Z:{spawnPointZ}");
            }
        }
    }
}