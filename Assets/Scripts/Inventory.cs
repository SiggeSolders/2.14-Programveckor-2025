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
        //detta g�r s� att inventoryt �r avst�ngt n�r man startar spelet
        playerinventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        //F�ljande kod g�r s� att n�r man trycker p� tab s� �ppnas inventoryt, d� s� st�ngs spelarens movement och kameran av vilket g�r s� att man inte kan r�ra sig och kursorn s�tts p�
    {
       if (Input.GetKeyDown(KeyCode.Tab) && playerinventory.activeSelf == false)
        {
            print("s�tt p�");
            playerinventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playermovement.enabled = false;
            camera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && playerinventory.activeSelf != false)
        {
            print("St�ng av");
            playerinventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playermovement.enabled = true;
            camera.enabled = true;
        }
        
    }
    public void HideCursor()
        //detta �r metoter som anges i buttons i spelet
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
