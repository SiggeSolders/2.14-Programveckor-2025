using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI soulText;
    [SerializeField] GameObject winScreen;
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
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (day)
        {
            case (1):
                moneyGoal = 100;
                soulGoal = 3;
                break;

            case (2):
                moneyGoal = 200;
                soulGoal = 6;
                break;

            case (3):
                moneyGoal = 250;
                soulGoal = 666;
                break;
        }
        
        moneyText.text = ("Money: " + money + ("/") + moneyGoal);
        soulText.text = ("Souls: " + souls + ("/") + soulGoal);

        if(day == 4)
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
