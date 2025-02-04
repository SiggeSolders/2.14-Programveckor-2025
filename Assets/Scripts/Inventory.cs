using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{

    public GameObject playerinventory;
    public PlayerMovement playermovement;
    public PlayerCamera camera;
    
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
            playermovement.enabled = false;
            camera.enabled = false;
        }
        
    }
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void closeinventory()
    {
        playerinventory.SetActive(false);
        playermovement.enabled = true;
        camera.enabled = true;
    }
}
