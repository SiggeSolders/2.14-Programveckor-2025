using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cost1Text;

    public int price1 = 50;
    public GameObject ShopUI;

    private GameObject objectToSell;
    public void buyButton1()
    {
        if (goalScript.money >= price1)
        {
            goalScript.money -= price1;
        }

    }
    
    GoalsScript goalScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopUI.SetActive(false);
        goalScript = FindObjectOfType<GoalsScript>();
        cost1Text.text = (price1 + " $");
    }
    
    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deer" || other.gameObject.tag == "Sheep")
        {
            if (other.gameObject.tag == "Deer")
            {
                objectToSell = GameObject.Find("holdPos/Deer");
                Destroy(objectToSell.gameObject);
                goalScript.money += 50;
            }
            if (other.gameObject.tag == "Sheep")
            {
                objectToSell = GameObject.Find("holdPos/Sheep");
                Destroy(objectToSell.gameObject);
                goalScript.money += 20;
            }

        }
        if (other.gameObject.tag == "Player")
        {
            ShopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            ShopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
}
