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
    private GameObject objectToSell;
    
    
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
    public void Item1()
    {
        item1.SetActive(true);
        goalScript.money -= 20;
    }
    public void Item2()
    {
        item2.SetActive(true);
        goalScript.money -= 30;
    }
    public void Item3()
    {
        item3.SetActive(true);
        goalScript.money -= 40;
    }
    public void Item4()
    {
        item4.SetActive(true);
        goalScript.money -= 50;
    }
    public void Item5()
    {
        item5.SetActive(true);
        goalScript.money -= 60;
    }
}
