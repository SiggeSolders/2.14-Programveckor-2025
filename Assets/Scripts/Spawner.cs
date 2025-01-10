using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject animal;
    int numberSpawned;
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
                numberSpawned = 5;
                break;
            case 2:
                numberSpawned = 10;
                break;
            case 3:
                numberSpawned = 15;
                break;
            default:
                numberSpawned = 0;
                break;
        }
        for (int i = 0; i < numberSpawned; i++)
        {
            int spawnPointX = Random.Range(-10, 52);
            int spawnPointZ = Random.Range(-50, 46);
            Vector3 spawnPoint = new Vector3(spawnPointX, 4, spawnPointZ);
            Instantiate(animal, spawnPoint, Quaternion.identity);
        }
    }
}