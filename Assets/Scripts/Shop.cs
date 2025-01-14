using JetBrains.Annotations;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int price1 = 20;
    public int price2 = 30;
    public int price3 = 40;
    public int price4 = 50;
    public int price5 = 60;
    public GameObject ShopUI;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;

    GoalsScript goalScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopUI.SetActive(false);
        goalScript = FindObjectOfType<GoalsScript>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deer" || other.gameObject.tag == "Sheep")
        {
            other.transform.parent.gameObject.SetActive(false);
            Destroy(other.gameObject);
            if (other.gameObject.tag == "Deer")
            {
                goalScript.money += 50;
            }
            if (other.gameObject.tag == "Sheep")
            {
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
        if (goalScript.money >= price1)
        {
            goalScript.money -= 20;
            item1.SetActive(true);
        }
        
    }
    public void Item2()
    {
        if (goalScript.money >= price1)
        {
            goalScript.money -= 30;
            item2.SetActive(true);
        }
        
    }
    public void Item3()
    {
        if (goalScript.money >= price1)
        {
            goalScript.money -= 40;
            item3.SetActive(true);
        }
        
    }
    public void Item4()
    {
        if (goalScript.money >= price1)
        {
            goalScript.money -= 50;
            item4.SetActive(true);
        }
        
    }
    public void Item5()
    {
        if (goalScript.money >= price1)
        {
            goalScript.money -= 60;
            item5.SetActive(true);
        }
        
    }
}
