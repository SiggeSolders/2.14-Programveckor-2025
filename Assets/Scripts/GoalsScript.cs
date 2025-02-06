using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI soulText;
    public int money;
    public int moneyGoal;
    public int soulGoal;
    public int souls;
    public int day;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        money = 0;
        souls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Ändrar goals beroende på vilken dag det är
        switch (day)
        {
            case (1):
                moneyGoal = 100;
                soulGoal = 1;
                break;

            case (2):
                moneyGoal = 200;
                soulGoal = 4;
                break;

            case (3):
                moneyGoal = 500;
                soulGoal = 666;
                break;


            case (4):
                moneyGoal = 0;
                soulGoal = 0;
                break;
        }
        
        moneyText.text = ("Money: " + money + ("/") + moneyGoal);
        soulText.text = ("Souls: " + souls + ("/") + soulGoal);

        if(day == 4)
        {
            //om man överlever de tre dagarna vinner man
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
