using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject deer;
    [SerializeField] GameObject sheep;
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
                deerNumberSpawned = 4;
                sheepNumberSpawned = 10;
                break;
            case 2:
                deerNumberSpawned = 6;
                sheepNumberSpawned = 20;
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
        for (int i = 0; i < deerNumberSpawned; i++)
        {
            int spawnPointX = Random.Range(2, 296);
            int spawnPointZ = Random.Range(2, 296);
            Vector3 spawnPoint = new Vector3(spawnPointX, 4, spawnPointZ);
            Instantiate(deer, spawnPoint, Quaternion.identity);
        }
        for (int i = 0; i < sheepNumberSpawned; i++)
        {
            int spawnPointX = Random.Range(2, 296);
            int spawnPointZ = Random.Range(2, 296);
            Vector3 spawnPoint = new Vector3(spawnPointX, 4, spawnPointZ);
            Instantiate(sheep, spawnPoint, Quaternion.identity);
        }
    }
}