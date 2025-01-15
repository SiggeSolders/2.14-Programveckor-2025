using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{

    public GameObject playerinventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerinventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerinventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
