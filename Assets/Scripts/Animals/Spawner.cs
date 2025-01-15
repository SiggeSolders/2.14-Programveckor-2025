using UnityEngine;
using UnityEngine.AI;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject deer;
    [SerializeField] GameObject sheep;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GoalsScript goalsScript;
    [SerializeField] float navMeshSampleDistance = 2f; // Max distans för att lägga dit den
    int deerNumberSpawned;
    int sheepNumberSpawned;
    int lastSpawnedDay = 0;

    void Start()
    {
        print(goalsScript);
    }

    // Update is called once per frame
    void Update()
    {
        // kollar om dagen ändrats
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
                sheepNumberSpawned = 10;
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
            // Skapar random spawnpunkt
            float spawnPointX = Random.Range(2, 296);
            float spawnPointZ = Random.Range(2, 296);
            Vector3 randomPoint = new Vector3(spawnPointX, 100f, spawnPointZ); // startar högt upp innan den kollar marken

            // Hittar marken
            if (Physics.Raycast(randomPoint, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                Vector3 groundPoint = hit.point;

                // Kollar om marken är på navmeshen och hamnar där om det är det
                if (NavMesh.SamplePosition(groundPoint, out NavMeshHit navHit, navMeshSampleDistance, NavMesh.AllAreas))
                {
                    Instantiate(animalPrefab, navHit.position, Quaternion.identity); 
                }

            }
        }
    }
}