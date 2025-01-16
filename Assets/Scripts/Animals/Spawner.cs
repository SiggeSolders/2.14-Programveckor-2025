using UnityEngine;
using UnityEngine.AI;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject deer;
    [SerializeField] GameObject sheep;
    [SerializeField] GameObject wolf;
    [SerializeField] LayerMask groundLayer; 
    [SerializeField] GoalsScript goalsScript;
    [SerializeField] float navMeshSampleDistance = 2f; // Max distans
    int deerNumberSpawned;
    int sheepNumberSpawned;
    int wolfNumberSpawned;
    int lastSpawnedDay = 0;

    // Start 
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

    //sätter antal djur per dag
    void SpawnAnimalsForDay(int day)
    {
        switch (day)
        {
            case 1:
                deerNumberSpawned = 10;
                sheepNumberSpawned = 10;
                wolfNumberSpawned = 4;
                break;
            case 2:
                deerNumberSpawned = 20;
                sheepNumberSpawned = 6;
                wolfNumberSpawned = 4;
                break;
            case 3:
                deerNumberSpawned = 10;
                sheepNumberSpawned = 30;
                wolfNumberSpawned = 4;
                break;
            default:
                deerNumberSpawned = 0;
                sheepNumberSpawned = 0;
                break;
        }

        SpawnAnimals(deer, deerNumberSpawned);
        SpawnAnimals(sheep, sheepNumberSpawned);
        SpawnAnimals(wolf, wolfNumberSpawned);
    }

    void SpawnAnimals(GameObject animalPrefab, int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            //Genererar slumpmässig plats innom ramarna
            float spawnPointX = Random.Range(2, 296);
            float spawnPointZ = Random.Range(2, 296);
            Vector3 randomPoint = new Vector3(spawnPointX, 100f, spawnPointZ); // Startar högt och kollar neråt

            if (Physics.Raycast(randomPoint, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                Vector3 groundPoint = hit.point;

                // Kollar om den över en navmesh surface
                if (NavMesh.SamplePosition(groundPoint, out NavMeshHit navHit, navMeshSampleDistance, NavMesh.AllAreas))
                {
                    Instantiate(animalPrefab, navHit.position, Quaternion.identity); // spawnar på marken
                }
            }
        }
    }
}