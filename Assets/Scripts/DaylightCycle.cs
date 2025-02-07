using UnityEngine;

public class day_night : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float dayCycleSpeed = 0.6f; // Rotation speed
    public float totalRotation = 0f;

    GoalsScript goalsScript;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Material daySkybox;
    [SerializeField] Material nightSkybox;
    public bool money = false;
    private void Start()
    {
        goalsScript = FindAnyObjectByType<GoalsScript>();
        gameOverScreen.SetActive(false);
        money = false;
        RenderSettings.skybox = daySkybox;
    }

    void Update()
    {
        //Kollar hur mycket den roterar varje frame och roterar med så mycket.
        float rotationThisFrame = dayCycleSpeed * Time.deltaTime;
        rotation.x = rotationThisFrame;
        transform.Rotate(rotation, Space.World);

        //totalRotation ökar så att när den har roterat ett helt varv blir det en ny dag.
        totalRotation += rotationThisFrame;

        if (totalRotation >= 360f)
        {
            goalsScript.money -= goalsScript.moneyGoal;
            goalsScript.souls -= goalsScript.soulGoal;
            totalRotation = 0f;
            goalsScript.day++;
            HandleEndOfDay();
        }


        UpdateSkyboxAndLighting();
    }

    //Om den har roterat mindre än ett halvt varv är skyboxen dag, annas är den natt
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

    //Om man har mindre pengar eller själar än man behöver, förlorar man, förutom dag 4 då man får ett val
    void HandleEndOfDay()
    {
        if (goalsScript.money < goalsScript.moneyGoal && goalsScript.day != 4)
        {
            money = true;
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (goalsScript.souls < goalsScript.soulGoal && goalsScript.day != 4)
        {
            money = false;
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (goalsScript.money >= goalsScript.moneyGoal && goalsScript.day == 4)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
