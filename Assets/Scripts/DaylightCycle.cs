using UnityEngine;

public class day_night : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float day_cycle = 1.2f;
    float totalRotation = 0f;
    GoalsScript goalsScript;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject ChoseScreen;


    private void Start()
    {
        goalsScript = FindAnyObjectByType<GoalsScript>();
        gameOverScreen.SetActive(false);
        ChoseScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        float rotationThisFrame = day_cycle * Time.deltaTime;

        // Roterar
        rotation.x = rotationThisFrame;
        transform.Rotate(rotation, Space.World);

        
        totalRotation += rotationThisFrame;

        if (totalRotation >= 360)
        {
            goalsScript.day++;
            totalRotation = 0;

            if((goalsScript.money < goalsScript.moneyGoal || goalsScript.souls < goalsScript.soulGoal) && goalsScript.day != 3)
            {
                gameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
            if ((goalsScript.money < goalsScript.moneyGoal) && goalsScript.day == 3)
            {
                gameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            if ((goalsScript.souls < goalsScript.soulGoal) && goalsScript.day == 3)
            {
                ChoseScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
}
