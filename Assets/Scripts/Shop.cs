using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cost1Text;

    public int price1 = 50;
    public GameObject ShopUI;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject inventoryitem1;
    public GameObject inventoryitem2;
    public GameObject inventoryitem3;
    public GameObject inventoryitem4;
    public GameObject inventoryitem5;
    public GameObject inventoryitem6;
    public PlayerCamera kamera;
    private GameObject objectToSell;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
    public GameObject weapon6;

    public PlayerMovement playermovement;
    GoalsScript goalScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopUI.SetActive(false);
        goalScript = FindObjectOfType<GoalsScript>();
        //cost1Text.text = price1 + " $";
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
                objectToSell = GameObject.Find("holdPos/Deer(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.money += 50;
            }
            if (other.gameObject.tag == "Sheep")
            {
                objectToSell = GameObject.Find("holdPos/Sheep(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.money += 20;
            }
            if (other.gameObject.tag == "Wolf")
            {
                objectToSell = GameObject.Find("holdPos/Wolf(Clone)");
                Destroy(objectToSell.gameObject);
                goalScript.money += 100;
            }

        }
        if (other.gameObject.tag == "Player")
        {
            ShopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playermovement.enabled = false;
            kamera.enabled = false;
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
    public void Item1()
    {
        item1.SetActive(true);
        inventoryitem1.SetActive(true);
        goalScript.money -= 20;
        weapon1.SetActive(true);
    }
    public void Item2()
    {
        item2.SetActive(true);
        inventoryitem2.SetActive(true);
        goalScript.money -= 30;
        weapon2.SetActive(true);
    }
    public void Item3()
    {
        item3.SetActive(true);
        inventoryitem3.SetActive(true);
        goalScript.money -= 40;
        weapon3.SetActive(true);
    }
    public void Item4()
    {
        item4.SetActive(true);
        inventoryitem4.SetActive(true);
        goalScript.money -= 50;
        weapon4.SetActive(true);
    }
    public void Item5()
    {
        item5.SetActive(true);
        inventoryitem5.SetActive(true);
        goalScript.money -= 60;
        weapon5.SetActive(true);
    }
    public void Item6()
    {
        item6.SetActive(true);
        inventoryitem6.SetActive(true);
        goalScript.money -= 70;
        weapon6.SetActive(true);
    }
    
    public void closeshop()
    {
        ShopUI.SetActive(false);
        playermovement.enabled = true;
        kamera.enabled = true;
    }
}
