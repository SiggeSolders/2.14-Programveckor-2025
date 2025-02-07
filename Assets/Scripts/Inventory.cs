using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    //Mira har gjort denna kod

    public GameObject playerinventory;
    public PlayerMovement playermovement;
    public PlayerCamera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //detta gör så att inventoryt är avstängt när man startar spelet
        playerinventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        //Följande kod gör så att när man trycker på tab så öppnas inventoryt, då så stängs spelarens movement och kameran av vilket gör så att man inte kan röra sig och kursorn sätts på
    {
       if (Input.GetKeyDown(KeyCode.Tab) && playerinventory.activeSelf == false)
        {
            print("sätt på");
            playerinventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playermovement.enabled = false;
            camera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && playerinventory.activeSelf != false)
        {
            print("Stäng av");
            playerinventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playermovement.enabled = true;
            camera.enabled = true;
        }
        
    }
    public void HideCursor()
        //detta är metoter som anges i buttons i spelet
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
