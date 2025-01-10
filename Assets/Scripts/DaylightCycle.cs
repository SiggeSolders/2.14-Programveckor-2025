using UnityEngine;

public class day_night : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float day_cycle = 1.2f;
    float totalRotation = 0f;
    GoalsScript goalsScript;
    [SerializeField] GameObject gameOverScreen;


    private void Start()
    {
        goalsScript = FindAnyObjectByType<GoalsScript>();
        gameOverScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        float rotationThisFrame = day_cycle * Time.deltaTime;

        // Roterar
        rotation.x = rotationThisFrame;
        transform.Rotate(rotation, Space.World);

        
        totalRotation += rotationThisFrame;

        if (totalRotation >= 360f)
        {
            goalsScript.day++;
            totalRotation = 0f;

            if((goalsScript.money < goalsScript.moneyGoal || goalsScript.souls < goalsScript.soulGoal) && goalsScript.day != 3)
            {
                gameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
