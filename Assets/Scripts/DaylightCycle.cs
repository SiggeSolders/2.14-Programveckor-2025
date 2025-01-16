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
        //skapar en variabel som håller koll på rotationen denna frame
        float rotationThisFrame = day_cycle * Time.deltaTime;

        // Roterar
        rotation.x = rotationThisFrame;
        transform.Rotate(rotation, Space.World);

        //ökar totalen med rotationen denna frame
        totalRotation += rotationThisFrame;
        //om den roterat ett helt varv ökar dagen med ett och totala rotationen sätts till noll
        if (totalRotation >= 360)
        {
            print("Day");
            goalsScript.day++;
            totalRotation = 0;

            //Om man inte har nog med själar eller pengar förlorar man och hamnar på förlora screen
            if((goalsScript.money < goalsScript.moneyGoal || goalsScript.souls < goalsScript.soulGoal) && goalsScript.day != 4)
            {
                gameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
                
            }
            //specialfall på dag 3 då man bara behöver pengar
            if ((goalsScript.money < goalsScript.moneyGoal) && goalsScript.day == 3)
            {
                gameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            
            }
            //om man klarar dag 3 kommer man till det sista valet 
            if ((goalsScript.money >= goalsScript.moneyGoal) && goalsScript.day == 4)
            {
                ChoseScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
}
