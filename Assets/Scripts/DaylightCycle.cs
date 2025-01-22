using UnityEngine;

public class day_night : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float dayCycleSpeed = 1.2f; // Rotation speed
    float totalRotation = 0f;

    GoalsScript goalsScript;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject chooseScreen;
    [SerializeField] Material daySkybox;
    [SerializeField] Material nightSkybox;

    private void Start()
    {
        goalsScript = FindAnyObjectByType<GoalsScript>();
        gameOverScreen.SetActive(false);
        chooseScreen.SetActive(false);

        RenderSettings.skybox = daySkybox; 
    }

    void Update()
    {

        float rotationThisFrame = dayCycleSpeed * Time.deltaTime;


        rotation.x = rotationThisFrame;
        transform.Rotate(rotation, Space.World);

        totalRotation += rotationThisFrame;

        if (totalRotation >= 360f)
        {
            totalRotation = 0f;
            goalsScript.day++;
            HandleEndOfDay();
        }


        UpdateSkyboxAndLighting();
    }

    void UpdateSkyboxAndLighting()
    {

        float normalizedTimeOfDay = totalRotation / 360f;



        if(normalizedTimeOfDay < 0.5f)
        {
            RenderSettings.skybox = daySkybox;
        }

        else
        {
            RenderSettings.skybox = nightSkybox;
        }

        DynamicGI.UpdateEnvironment();
    }

    void HandleEndOfDay()
    {
        if ((goalsScript.money < goalsScript.moneyGoal || goalsScript.souls < goalsScript.soulGoal) && goalsScript.day != 4)
        {
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (goalsScript.money < goalsScript.moneyGoal && goalsScript.day == 3)
        {
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (goalsScript.money >= goalsScript.moneyGoal && goalsScript.day == 4)
        {
            chooseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
